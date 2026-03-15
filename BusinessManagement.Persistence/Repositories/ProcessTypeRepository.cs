using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.Domain.Entities;
using BusinessManagement.DTO.ProcessTypeDTOs;
using BusinessManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManagement.Persistence.Repositories
{
    public class ProcessTypeRepository : IProcessTypeRepository
    {
        private readonly BusinessManagementDbContext _context;
        public ProcessTypeRepository(BusinessManagementDbContext context)
        {
            _context = context;
        }

        public async Task<AddProcessTypeDto> AddProcessTypeAsync(AddProcessTypeDto dto)
        {
            var entity = new ProcessType
            {
                Name = dto.Name,
                Description = dto.Description,
                CreateDate = dto.CreateDate,
                IsDeleted = dto.IsDeleted
            };
            _context.ProcessTypes.Add(entity);
            await _context.SaveChangesAsync();
            return dto;
        }

        public Task DeleteProcessTypeAsync(int id)
        {
            var entity = _context.ProcessTypes.Find(id);
            if (entity == null || entity.IsDeleted)
            {
                throw new KeyNotFoundException($"ProcessType bulunamadı ID = {id}  (404)");
            }
            entity.IsDeleted = true;
            _context.ProcessTypes.Update(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<List<ResponseProcessTypeDto>> GetAllAsync()
        {
            var entities = await _context.ProcessTypes
                .Where(b => !b.IsDeleted)
                .Select(b => new ResponseProcessTypeDto
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

        public async Task<UpdateProcessTypeDto> UpdateProcessTypeAsync(int id, UpdateProcessTypeDto dto)
        {
            var entity = await _context.ProcessTypes.FindAsync(id);
            if (entity == null || entity.IsDeleted)
            {
                throw new KeyNotFoundException($"ProcessType bulunamadı ID = {id}  (404)");
            }
            var updatedEntity = new ProcessType
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
