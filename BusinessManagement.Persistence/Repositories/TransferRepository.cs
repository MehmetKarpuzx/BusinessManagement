using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.Domain.Entities;
using BusinessManagement.DTO.TransferDTOs;
using BusinessManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManagement.Persistence.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        private readonly BusinessManagementDbContext _context;
        public TransferRepository(BusinessManagementDbContext context)
        {
            _context = context;
        }

        public async Task<AddTransferDto> AddTransferAsync(AddTransferDto dto)
        {
            var entity = new Transfer
            {
                ProductionId = dto.ProductionId,
                TransferAmount = dto.TransferAmount,
                BranchId = dto.BranchId,
                TransferDate = dto.TransferDate,
                Description = dto.Description
            };
            _context.Transfers.Add(entity);
            await _context.SaveChangesAsync();
            return dto;
        }

        public Task DeleteTransferAsync(int id)
        {
            var entity = _context.Transfers.Find(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Transfer bulunamadı ID = {id}  (404)");
            }
            _context.Transfers.Remove(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<List<ResponseTransferDto>> GetAllAsync()
        {
            var entities = await _context.Transfers
                .Select(b => new ResponseTransferDto
                {
                    Id = b.Id,
                    ProductionId = b.ProductionId,
                    TransferAmount = b.TransferAmount,
                    BranchId = b.BranchId,
                    TransferDate = b.TransferDate,
                    Description = b.Description
                })
                .ToListAsync();
            return entities;    
        }

        public async Task<UpdateTransferDto> UpdateTransferAsync(int id, UpdateTransferDto dto)
        {
            var entity = await _context.Transfers.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Transfer bulunamadı ID = {id}  (404)");
            }
            var updatedEntity = new Transfer
            {
                Id = id,
                ProductionId = dto.ProductionId,
                TransferAmount = dto.TransferAmount,
                BranchId = dto.BranchId,
                TransferDate = dto.TransferDate,
                Description = dto.Description
            };
            _context.Entry(entity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return dto;
        }
    }
}
