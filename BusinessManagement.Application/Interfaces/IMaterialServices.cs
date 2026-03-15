using BusinessManagement.DTO.MaterialDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Interfaces
{
    public interface IMaterialServices
    {
        Task<List<ResponseMaterialDto>> GetAllAsync();
        Task<AddMaterialDto> AddMaterialAsync(AddMaterialDto materialDto);
        Task<UpdateMaterialDto> UpdateMaterialAsync(int id, UpdateMaterialDto materialDto);
        Task DeleteMaterialAsync(int id);
    }
}
