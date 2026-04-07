using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.Domain.Entities;
using BusinessManagement.DTO.UserDTOs;
using BusinessManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BusinessManagementDbContext _context;
        public UserRepository(BusinessManagementDbContext context)
        {
            _context = context;
        }

        public async Task<List<ResponseUserDto>> GetAllAsync()
        {
            return await _context.Users
                .Select(u => new ResponseUserDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Surname = u.Surname,
                    Username = u.Username,
                    RolId = u.RolId,
                    CreatedDate = u.CreatedDate,
                    IsActive = u.IsActive
                }).ToListAsync();
        }

        public async Task<AddUserDto> AddAsync(AddUserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Username = dto.Username,
                PasswordHash = dto.PasswordHash,
                RolId = dto.RolId,
                CreatedDate = dto.CreatedDate,
                IsActive = dto.IsActive
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<UpdateUserDto> UpdateAsync(int id, UpdateUserDto dto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            user.Name = dto.Name;
            user.Surname = dto.Surname;
            user.Username = dto.Username;
            user.PasswordHash = dto.PasswordHash;
            user.RolId = dto.RolId;
            user.IsActive = dto.IsActive;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
