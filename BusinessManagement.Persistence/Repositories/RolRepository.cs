using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.Domain.Entities;
using BusinessManagement.DTO.RolDTOs;
using BusinessManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement.Persistence.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly BusinessManagementDbContext _context;
        public RolRepository(BusinessManagementDbContext context)
        {
            _context = context;
        }

        public async Task<List<ResponseRolDto>> GetAllAsync()
        {
            return await _context.Rols
                .Select(r => new ResponseRolDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    CreatedDate = r.CreatedDate,
                    IsActive = r.IsActive
                }).ToListAsync();
        }

        public async Task<AddRolDto> AddAsync(AddRolDto dto)
        {
            var rol = new Rol
            {
                Name = dto.Name,
                Description = dto.Description,
                CreatedDate = dto.CreatedDate,
                IsActive = dto.IsActive
            };
            await _context.Rols.AddAsync(rol);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<UpdateRolDto> UpdateAsync(int id, UpdateRolDto dto)
        {
            var rol = await _context.Rols.FindAsync(id);
            if (rol == null) return null;

            rol.Name = dto.Name;
            rol.Description = dto.Description;
            rol.IsActive = dto.IsActive;

            _context.Rols.Update(rol);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var rol = await _context.Rols.FindAsync(id);
            if (rol != null)
            {
                _context.Rols.Remove(rol);
                await _context.SaveChangesAsync();
            }
        }
    }
}
