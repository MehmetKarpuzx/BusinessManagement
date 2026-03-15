using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.Domain.Entities;
using BusinessManagement.DTO.PaymentDTOs;
using BusinessManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManagement.Persistence.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly BusinessManagementDbContext _context;
        public PaymentRepository(BusinessManagementDbContext context)
        {
            _context = context;
        }

        public async Task<AddPaymentDto> AddPaymentAsync(AddPaymentDto dto)
        {
            var entity = new Payment
            {
                CustomerId = dto.CustomerId,
                PaymentAmount = dto.PaymentAmount,
                PaymentDate = dto.PaymentDate,
                DiscountAmount = dto.DiscountAmount,
                DiscountDescription = dto.DiscountDescription
            };
            _context.Payments.Add(entity);
            await _context.SaveChangesAsync();
            return dto;
        }

        public Task DeletePaymentAsync(int id)
        {
            var entity = _context.Payments.Find(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Payment bulunamadı ID = {id}  (404)");
            }
            _context.Payments.Remove(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<List<ResponsePaymentDto>> GetAllAsync()
        {
            var entities = await _context.Payments
                .Select(b => new ResponsePaymentDto
                {
                    Id = b.Id,
                    CustomerId = b.CustomerId,
                    PaymentAmount = b.PaymentAmount,
                    PaymentDate = b.PaymentDate,
                    DiscountAmount = b.DiscountAmount,
                    DiscountDescription = b.DiscountDescription
                })
                .ToListAsync();
            return entities;    
        }

        public async Task<UpdatePaymentDto> UpdatePaymentAsync(int id, UpdatePaymentDto dto)
        {
            var entity = await _context.Payments.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Payment bulunamadı ID = {id}  (404)");
            }
            var updatedEntity = new Payment
            {
                Id = id,
                CustomerId = dto.CustomerId,
                PaymentAmount = dto.PaymentAmount,
                PaymentDate = dto.PaymentDate,
                DiscountAmount = dto.DiscountAmount,
                DiscountDescription = dto.DiscountDescription
            };
            _context.Entry(entity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return dto;
        }
    }
}
