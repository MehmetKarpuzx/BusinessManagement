using BusinessManagement.DTO.RolDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Interfaces
{
    public interface IRolServices
    {
        Task<List<ResponseRolDto>> GetAllAsync();
        Task<AddRolDto> AddAsync(AddRolDto dto);
        Task<UpdateRolDto> UpdateAsync(int id, UpdateRolDto dto);
        Task DeleteAsync(int id);
    }
}
