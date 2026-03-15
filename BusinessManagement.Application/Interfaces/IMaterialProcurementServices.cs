using BusinessManagement.DTO.MaterialProcurementDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Interfaces
{
    public interface IMaterialProcurementServices
    {
        Task<List<ResponseMaterialProcurementDto>> GetAllAsync();
        Task<AddMaterialProcurementDto> AddMaterialProcurementAsync(AddMaterialProcurementDto materialProcurementDto);
        Task<UpdateMaterialProcurementDto> UpdateMaterialProcurementAsync(int id, UpdateMaterialProcurementDto materialProcurementDto);
        Task DeleteMaterialProcurementAsync(int id);
    }
}
