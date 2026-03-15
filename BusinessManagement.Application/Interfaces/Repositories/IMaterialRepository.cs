using BusinessManagement.DTO.MaterialDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Interfaces.Repositories
{
    public interface IMaterialRepository
    {
        Task<List<ResponseMaterialDto>> GetAllAsync();
        Task<AddMaterialDto> AddMaterialAsync(AddMaterialDto materialDto);
        Task<UpdateMaterialDto> UpdateMaterialAsync(int id, UpdateMaterialDto materialDto);
        Task DeleteMaterialAsync(int id);
    }
}
