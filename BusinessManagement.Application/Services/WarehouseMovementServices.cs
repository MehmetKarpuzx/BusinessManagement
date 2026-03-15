using BusinessManagement.Application.Interfaces;
using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.DTO.WarehouseMovementDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.Application.Services
{
    public class WarehouseMovementServices : IWarehouseMovementServices
    {
        private readonly IWarehouseMovementRepository _repository;
        public WarehouseMovementServices(IWarehouseMovementRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddWarehouseMovementDto> AddWarehouseMovementAsync(AddWarehouseMovementDto dto)
        {
            return await _repository.AddWarehouseMovementAsync(dto);
        }

        public Task DeleteWarehouseMovementAsync(int id)
        {
            return _repository.DeleteWarehouseMovementAsync(id);
        }

        public async Task<List<ResponseWarehouseMovementDto>> GetAllAsync()
        {
           return await _repository.GetAllAsync();
        }

        public async Task<UpdateWarehouseMovementDto> UpdateWarehouseMovementAsync(int id, UpdateWarehouseMovementDto dto)
        {
            return await _repository.UpdateWarehouseMovementAsync(id, dto);
        }
    }
}
