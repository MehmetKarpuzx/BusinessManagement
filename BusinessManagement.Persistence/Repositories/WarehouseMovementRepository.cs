using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.Domain.Entities;
using BusinessManagement.DTO.WarehouseMovementDTOs;
using BusinessManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManagement.Persistence.Repositories
{
    public class WarehouseMovementRepository : IWarehouseMovementRepository
    {
        private readonly BusinessManagementDbContext _context;
        public WarehouseMovementRepository(BusinessManagementDbContext context)
        {
            _context = context;
        }

        public async Task<AddWarehouseMovementDto> AddWarehouseMovementAsync(AddWarehouseMovementDto dto)
        {
            var entity = new WarehouseMovement
            {
                ProcessTypeId = dto.ProcessTypeId,
                SupplierId = dto.SupplierId,
                MaterialId = dto.MaterialId,
                UnitPrice = dto.UnitPrice,
                Amount = dto.Amount,
                TotalPrice = dto.TotalPrice,
                InvoiceNo = dto.InvoiceNo,
                BranchId = dto.BranchId,
                TransactionDate = dto.TransactionDate,
                Description = dto.Description
            };
            _context.WarehouseMovements.Add(entity);
            await _context.SaveChangesAsync();
            return dto;
        }

        public Task DeleteWarehouseMovementAsync(int id)
        {
            var entity = _context.WarehouseMovements.Find(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"WarehouseMovement bulunamadı ID = {id}  (404)");
            }
            _context.WarehouseMovements.Remove(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<List<ResponseWarehouseMovementDto>> GetAllAsync()
        {
            var entities = await _context.WarehouseMovements
                .Select(b => new ResponseWarehouseMovementDto
                {
                    Id = b.Id,
                    ProcessTypeId = b.ProcessTypeId,
                    SupplierId = b.SupplierId,
                    MaterialId = b.MaterialId,
                    UnitPrice = b.UnitPrice,
                    Amount = b.Amount,
                    TotalPrice = b.TotalPrice,
                    InvoiceNo = b.InvoiceNo,
                    BranchId = b.BranchId,
                    TransactionDate = b.TransactionDate,
                    Description = b.Description
                })
                .ToListAsync();
            return entities;    
        }

        public async Task<UpdateWarehouseMovementDto> UpdateWarehouseMovementAsync(int id, UpdateWarehouseMovementDto dto)
        {
            var entity = await _context.WarehouseMovements.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"WarehouseMovement bulunamadı ID = {id}  (404)");
            }
            var updatedEntity = new WarehouseMovement
            {
                Id = id,
                ProcessTypeId = dto.ProcessTypeId,
                SupplierId = dto.SupplierId,
                MaterialId = dto.MaterialId,
                UnitPrice = dto.UnitPrice,
                Amount = dto.Amount,
                TotalPrice = dto.TotalPrice,
                InvoiceNo = dto.InvoiceNo,
                BranchId = dto.BranchId,
                TransactionDate = dto.TransactionDate,
                Description = dto.Description
            };
            _context.Entry(entity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return dto;
        }
    }
}
