using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.Domain.Entities;
using BusinessManagement.DTO.CustomerDTOs;
using BusinessManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManagement.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BusinessManagementDbContext _context;
        public CustomerRepository(BusinessManagementDbContext context)
        {
            _context = context;
        }

        public async Task<AddCustomerDto> AddAsync(AddCustomerDto dto)
        {
            var entity = new Customer
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                CustomerTypeId = dto.CustomerTypeId,
                Adress = dto.Adress,
                CreateDate = dto.CreateDate
               
            };
            _context.Customers.Add(entity);
            await _context.SaveChangesAsync();
            return dto;
        }

        public Task DeleteAsync(int id)
        {
            var entity = _context.Customers.Find(id);
            if (entity == null || entity.IsDeleted)
            {
                throw new KeyNotFoundException($"Customer bulunamadı ID = {id}  (404)");
            }
            entity.IsDeleted = true;
            _context.Customers.Update(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<List<ResponseCustomerDto>> GetAllAsync()
        {
            var entities = await _context.Customers
                .Where(b => !b.IsDeleted)
                .Select(b => new ResponseCustomerDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    Surname = b.Surname,
                    Email = b.Email,
                    PhoneNumber = b.PhoneNumber,
                    CustomerTypeId = b.CustomerTypeId,
                    Adress = b.Adress,
                    CreateDate = b.CreateDate,
                    IsDeleted = b.IsDeleted
                })
                .ToListAsync();
            return entities;    
        }

        public async Task<UpdateCustomerDto> UpdateAsync(int id, UpdateCustomerDto dto)
        {
            var entity = await _context.Customers.FindAsync(id);
            if (entity == null || entity.IsDeleted)
            {
                throw new KeyNotFoundException($"Customer bulunamadı ID = {id}  (404)");
            }
            var updatedEntity = new Customer
            {
                Id = id,
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                CustomerTypeId = dto.CustomerTypeId,
                Adress = dto.Adress,
                IsDeleted = dto.IsDeleted
            };
            _context.Entry(entity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return dto;
        }
    }
}
