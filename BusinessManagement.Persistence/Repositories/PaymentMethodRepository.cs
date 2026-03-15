using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.Domain.Entities;
using BusinessManagement.DTO.PaymentMethodDTOs;
using BusinessManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManagement.Persistence.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly BusinessManagementDbContext _context;
        public PaymentMethodRepository(BusinessManagementDbContext context)
        {
            _context = context;
        }

        public async Task<AddPaymentMethodDto> AddPaymentMethodAsync(AddPaymentMethodDto dto)
        {
            var entity = new PaymentMethod
            {
                Name = dto.Name,
                Description = dto.Description,
                CreateDate = dto.CreateDate,
                IsDeleted = dto.IsDeleted
            };
            _context.PaymentMethods.Add(entity);
            await _context.SaveChangesAsync();
            return dto;
        }

        public Task DeletePaymentMethodAsync(int id)
        {
            var entity = _context.PaymentMethods.Find(id);
            if (entity == null || entity.IsDeleted)
            {
                throw new KeyNotFoundException($"PaymentMethod bulunamadı ID = {id}  (404)");
            }
            entity.IsDeleted = true;
            _context.PaymentMethods.Update(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<List<ResponsePaymentMethodDto>> GetAllAsync()
        {
            var entities = await _context.PaymentMethods
                .Where(b => !b.IsDeleted)
                .Select(b => new ResponsePaymentMethodDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    Description = b.Description,
                    CreateDate = b.CreateDate,
                    IsDeleted = b.IsDeleted
                })
                .ToListAsync();
            return entities;    
        }

        public async Task<UpdatePaymentMethodDto> UpdatePaymentMethodAsync(int id, UpdatePaymentMethodDto dto)
        {
            var entity = await _context.PaymentMethods.FindAsync(id);
            if (entity == null || entity.IsDeleted)
            {
                throw new KeyNotFoundException($"PaymentMethod bulunamadı ID = {id}  (404)");
            }
            var updatedEntity = new PaymentMethod
            {
                Id = id,
                Name = dto.Name,
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
