using BusinessManagement.MVC.DTO.WarehouseMovementDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.MVC.Application.Interfaces
{
    public interface IWarehouseMovementServices
    {
        Task<List<ResultWarehouseMovementDto>> GetAllWarehouseMovementsAsync();
        Task<AddWarehouseMovementDto> AddWarehouseMovementAsync(AddWarehouseMovementDto addWarehouseMovementDto);
        Task<UpdateWarehouseMovementDto> UpdateWarehouseMovementAsync(UpdateWarehouseMovementDto updateWarehouseMovementDto, int id);
        Task DeleteWarehouseMovementAsync(int id);
    }
}
