using BusinessManagement.DTO.WarehouseMovementDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Interfaces
{
    public interface IWarehouseMovementServices
    {
        Task<List<ResponseWarehouseMovementDto>> GetAllAsync();
        Task<AddWarehouseMovementDto> AddWarehouseMovementAsync(AddWarehouseMovementDto warehouseMovementDto);
        Task<UpdateWarehouseMovementDto> UpdateWarehouseMovementAsync(int id, UpdateWarehouseMovementDto warehouseMovementDto);
        Task DeleteWarehouseMovementAsync(int id);
    }
}
