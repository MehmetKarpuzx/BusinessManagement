using BusinessManagement.MVC.DTO.MaterialProcurementDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.MVC.Application.Interfaces
{
    public interface IMaterialProcurementServices
    {
        Task<List<ResultMaterialProcurementDto>> GetAllMaterialProcurementsAsync();
        Task<AddMaterialProcurementDto> AddMaterialProcurementAsync(AddMaterialProcurementDto addMaterialProcurementDto);
        Task<UpdateMaterialProcurementDto> UpdateMaterialProcurementAsync(UpdateMaterialProcurementDto updateMaterialProcurementDto, int id);
        Task DeleteMaterialProcurementAsync(int id);
    }
}
