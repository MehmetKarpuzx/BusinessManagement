using BusinessManagement.MVC.DTO.UnitDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.MVC.Application.Interfaces
{
    public interface IUnitServices
    {
        Task<List<ResultUnitDto>> GetAllUnitsAsync();
        Task<AddUnitDto> AddUnitAsync(AddUnitDto addUnitDto);
        Task<UpdateUnitDto> UpdateUnitAsync(UpdateUnitDto updateUnitDto, int id);
        Task DeleteUnitAsync(int id);
    }
}
