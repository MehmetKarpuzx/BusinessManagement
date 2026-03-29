using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.Domain.Entities;
using BusinessManagement.DTO.UnitDTOs;
using BusinessManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManagement.Persistence.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly BusinessManagementDbContext _context;
        public UnitRepository(BusinessManagementDbContext context)
        {
            _context = context;
        }

        public async Task<AddUnitDto> AddUnitAsync(AddUnitDto dto)
        {
            var entity = new Unit
            {
                Name = dto.Name,
                Description = dto.Description,
                CreateDate = dto.CreateDate
               
            };
            _context.Units.Add(entity);
            await _context.SaveChangesAsync();
            return dto;
        }

        public Task DeleteUnitAsync(int id)
        {
            var entity = _context.Units.Find(id);
            if (entity == null || entity.IsDeleted)
            {
                throw new KeyNotFoundException($"Unit bulunamadı ID = {id}  (404)");
            }
            entity.IsDeleted = true;
            _context.Units.Update(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<List<ResponseUnitDto>> GetAllAsync()
        {
            var entities = await _context.Units
                .Where(b => !b.IsDeleted)
                .Select(b => new ResponseUnitDto
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

        public async Task<UpdateUnitDto> UpdateUnitAsync(int id, UpdateUnitDto dto)
        {
            var entity = await _context.Units.FindAsync(id);
            if (entity == null || entity.IsDeleted)
            {
                throw new KeyNotFoundException($"Unit bulunamadı ID = {id}  (404)");
            }
            var updatedEntity = new Unit
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
