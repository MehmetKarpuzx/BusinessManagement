using BusinessManagement.MVC.DTO.MaterialDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.MVC.Application.Interfaces
{
    public interface IMaterialServices
    {
        Task<List<ResultMaterialDto>> GetAllMaterialsAsync();
        Task<AddMaterialDto> AddMaterialAsync(AddMaterialDto addMaterialDto);
        Task<UpdateMaterialDto> UpdateMaterialAsync(UpdateMaterialDto updateMaterialDto, int id);
        Task DeleteMaterialAsync(int id);
    }
}
