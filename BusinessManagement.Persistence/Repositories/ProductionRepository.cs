using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.Domain.Entities;
using BusinessManagement.DTO.ProductionDTOs;
using BusinessManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManagement.Persistence.Repositories
{
    public class ProductionRepository : IProductionRepository
    {
        private readonly BusinessManagementDbContext _context;
        public ProductionRepository(BusinessManagementDbContext context)
        {
            _context = context;
        }

        public async Task<AddProductionDto> AddProductionAsync(AddProductionDto dto)
        {
            var entity = new Production
            {
                ProductId = dto.ProductId,
                Amount = dto.Amount,
                UnitTypeId = dto.UnitTypeId,
                CostPrice = dto.CostPrice,
                CreateDate = dto.CreateDate,
                BranchId = dto.BranchId,
                TotalPrice = dto.TotalPrice,
                Description = dto.Description
            };
            _context.Productions.Add(entity);
            await _context.SaveChangesAsync();
            return dto;
        }

        public Task DeleteProductionAsync(int id)
        {
            var entity = _context.Productions.Find(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Production bulunamadı ID = {id}  (404)");
            }
            _context.Productions.Remove(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<List<ResponseProductionDto>> GetAllAsync()
        {
            var entities = await _context.Productions
                .Select(b => new ResponseProductionDto
                {
                    Id = b.Id,
                    ProductId = b.ProductId,
                    Amount = b.Amount,
                    UnitTypeId = b.UnitTypeId,
                    CostPrice = b.CostPrice,
                    CreateDate = b.CreateDate,
                    BranchId = b.BranchId,
                    TotalPrice = b.TotalPrice,
                    Description = b.Description
                })
                .ToListAsync();
            return entities;    
        }

        public async Task<UpdateProductionDto> UpdateProductionAsync(int id, UpdateProductionDto dto)
        {
            var entity = await _context.Productions.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Production bulunamadı ID = {id}  (404)");
            }
            var updatedEntity = new Production
            {
                Id = id,
                ProductId = dto.ProductId,
                Amount = dto.Amount,
                UnitTypeId = dto.UnitTypeId,
                CostPrice = dto.CostPrice,
                CreateDate = dto.CreateDate,
                BranchId = dto.BranchId,
                TotalPrice = dto.TotalPrice,
                Description = dto.Description
            };
            _context.Entry(entity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return dto;
        }
    }
}
