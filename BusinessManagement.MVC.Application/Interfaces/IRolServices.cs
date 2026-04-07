using BusinessManagement.MVC.DTO.RolDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.MVC.Application.Interfaces
{
    public interface IRolServices
    {
        Task<List<ResultRolDto>> GetAllRolsAsync();
        Task<AddRolDto> AddRolAsync(AddRolDto dto);
        Task<UpdateRolDto> UpdateRolAsync(UpdateRolDto dto, int id);
        Task DeleteRolAsync(int id);
    }
}
