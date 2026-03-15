using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.Domain.Entities;
using BusinessManagement.DTO.MaterialDTOs;
using BusinessManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManagement.Persistence.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly BusinessManagementDbContext _context;
        public MaterialRepository(BusinessManagementDbContext context)
        {
            _context = context;
        }

        public async Task<AddMaterialDto> AddMaterialAsync(AddMaterialDto dto)
        {
            var entity = new Material
            {
                Name = dto.Name,
                UnitTypeId = dto.UnitTypeId,
                MinStock = dto.MinStock,
                Description = dto.Description
            };
            _context.Materials.Add(entity);
            await _context.SaveChangesAsync();
            return dto;
        }

        public Task DeleteMaterialAsync(int id)
        {
            var entity = _context.Materials.Find(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Material bulunamadı ID = {id}  (404)");
            }
            _context.Materials.Remove(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<List<ResponseMaterialDto>> GetAllAsync()
        {
            var entities = await _context.Materials
                .Select(b => new ResponseMaterialDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    UnitTypeId = b.UnitTypeId,
                    MinStock = b.MinStock,
                    Description = b.Description
                })
                .ToListAsync();
            return entities;    
        }

        public async Task<UpdateMaterialDto> UpdateMaterialAsync(int id, UpdateMaterialDto dto)
        {
            var entity = await _context.Materials.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Material bulunamadı ID = {id}  (404)");
            }
            var updatedEntity = new Material
            {
                Id = id,
                Name = dto.Name,
                UnitTypeId = dto.UnitTypeId,
                MinStock = dto.MinStock,
                Description = dto.Description
            };
            _context.Entry(entity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return dto;
        }
    }
}
