using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.Domain.Entities;
using BusinessManagement.DTO.SupplierDTOs;
using BusinessManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManagement.Persistence.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly BusinessManagementDbContext _context;
        public SupplierRepository(BusinessManagementDbContext context)
        {
            _context = context;
        }

        public async Task<AddSupplierDto> AddSupplierAsync(AddSupplierDto dto)
        {
            var entity = new Supplier
            {
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                Adress = dto.Adress,
                Description = dto.Description,
                CreateDate = dto.CreateDate,
                IsDeleted = dto.IsDeleted
            };
            _context.Suppliers.Add(entity);
            await _context.SaveChangesAsync();
            return dto;
        }

        public Task DeleteSupplierAsync(int id)
        {
            var entity = _context.Suppliers.Find(id);
            if (entity == null || entity.IsDeleted)
            {
                throw new KeyNotFoundException($"Supplier bulunamadı ID = {id}  (404)");
            }
            entity.IsDeleted = true;
            _context.Suppliers.Update(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<List<ResponseSupplierDto>> GetAllAsync()
        {
            var entities = await _context.Suppliers
                .Where(b => !b.IsDeleted)
                .Select(b => new ResponseSupplierDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    PhoneNumber = b.PhoneNumber,
                    Email = b.Email,
                    Adress = b.Adress,
                    Description = b.Description,
                    CreateDate = b.CreateDate,
                    IsDeleted = b.IsDeleted
                })
                .ToListAsync();
            return entities;    
        }

        public async Task<UpdateSupplierDto> UpdateSupplierAsync(int id, UpdateSupplierDto dto)
        {
            var entity = await _context.Suppliers.FindAsync(id);
            if (entity == null || entity.IsDeleted)
            {
                throw new KeyNotFoundException($"Supplier bulunamadı ID = {id}  (404)");
            }
            var updatedEntity = new Supplier
            {
                Id = id,
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                Adress = dto.Adress,
                Description = dto.Description,
                CreateDate = dto.CreateDate,
                IsDeleted = dto.IsDeleted
            };
            _context.Entry(entity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return dto;
        }
    }
}
