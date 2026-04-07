using BusinessManagement.DTO.UserDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<List<ResponseUserDto>> GetAllAsync();
        Task<AddUserDto> AddAsync(AddUserDto dto);
        Task<UpdateUserDto> UpdateAsync(int id, UpdateUserDto dto);
        Task DeleteAsync(int id);


    }
}
