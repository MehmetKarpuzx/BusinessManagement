using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.Domain.Entities;
using BusinessManagement.DTO.OrderDTOs;
using BusinessManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManagement.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BusinessManagementDbContext _context;
        public OrderRepository(BusinessManagementDbContext context)
        {
            _context = context;
        }

        public async Task<AddOrderDto> AddOrderAsync(AddOrderDto dto)
        {
            var entity = new Order
            {
                CustomerId = dto.CustomerId,
                BranchId = dto.BranchId,
                ProductId = dto.ProductId,
                Amount = dto.Amount,
                TotalPrice = dto.TotalPrice,
                OrderDate = dto.OrderDate,
                OrderStatus = dto.OrderStatus,
                CargoCompanyId = dto.CargoCompanyId,
                CargoPrice = dto.CargoPrice,
                CargoDescription = dto.CargoDescription,
                DiscountPrice = dto.DiscountPrice,
                DiscountDescription = dto.DiscountDescription,
                PaymentReceived = dto.PaymentReceived,
                RemainderPrice = dto.RemainderPrice,
                Description = dto.Description
            };
            _context.Orders.Add(entity);
            await _context.SaveChangesAsync();
            return dto;
        }

        public Task DeleteOrderAsync(int id)
        {
            var entity = _context.Orders.Find(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Order bulunamadı ID = {id}  (404)");
            }
            _context.Orders.Remove(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<List<ResponseOrderDto>> GetAllAsync()
        {
            var entities = await _context.Orders
                .Select(b => new ResponseOrderDto
                {
                    Id = b.Id,
                    CustomerId = b.CustomerId,
                    BranchId = b.BranchId,
                    ProductId = b.ProductId,
                    Amount = b.Amount,
                    TotalPrice = b.TotalPrice,
                    OrderDate = b.OrderDate,
                    OrderStatus = b.OrderStatus,
                    CargoCompanyId = b.CargoCompanyId,
                    CargoPrice = b.CargoPrice,
                    CargoDescription = b.CargoDescription,
                    DiscountPrice = b.DiscountPrice,
                    DiscountDescription = b.DiscountDescription,
                    PaymentReceived = b.PaymentReceived,
                    RemainderPrice = b.RemainderPrice,
                    Description = b.Description
                })
                .ToListAsync();
            return entities;    
        }

        public async Task<UpdateOrderDto> UpdateOrderAsync(int id, UpdateOrderDto dto)
        {
            var entity = await _context.Orders.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Order bulunamadı ID = {id}  (404)");
            }
            var updatedEntity = new Order
            {
                Id = id,
                CustomerId = dto.CustomerId,
                BranchId = dto.BranchId,
                ProductId = dto.ProductId,
                Amount = dto.Amount,
                TotalPrice = dto.TotalPrice,
                OrderDate = dto.OrderDate,
                OrderStatus = dto.OrderStatus,
                CargoCompanyId = dto.CargoCompanyId,
                CargoPrice = dto.CargoPrice,
                CargoDescription = dto.CargoDescription,
                DiscountPrice = dto.DiscountPrice,
                DiscountDescription = dto.DiscountDescription,
                PaymentReceived = dto.PaymentReceived,
                RemainderPrice = dto.RemainderPrice,
                Description = dto.Description
            };
            _context.Entry(entity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return dto;
        }
    }
}
