using BusinessManagement.Application.Interfaces;
using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.DTO.UserDTOs;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<ResponseUserDto>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<AddUserDto> AddAsync(AddUserDto dto)
        {
            // Hash password
            dto.PasswordHash = GetSha256Hash(dto.PasswordHash);
            dto.CreatedDate = DateTime.Now;
            dto.IsActive = true;

            return await _userRepository.AddAsync(dto);
        }

        public async Task<UpdateUserDto> UpdateAsync(int id, UpdateUserDto dto)
        {
            // Hash password if modified
            if (!string.IsNullOrEmpty(dto.PasswordHash))
            {
                dto.PasswordHash = GetSha256Hash(dto.PasswordHash);
            }
            return await _userRepository.UpdateAsync(id, dto);
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        private string GetSha256Hash(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
