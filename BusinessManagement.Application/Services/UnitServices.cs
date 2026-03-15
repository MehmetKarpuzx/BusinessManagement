using BusinessManagement.Application.Interfaces;
using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.DTO.UnitDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.Application.Services
{
    public class UnitServices : IUnitServices
    {
        private readonly IUnitRepository _repository;
        public UnitServices(IUnitRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddUnitDto> AddUnitAsync(AddUnitDto dto)
        {
            return await _repository.AddUnitAsync(dto);
        }

        public Task DeleteUnitAsync(int id)
        {
            return _repository.DeleteUnitAsync(id);
        }

        public async Task<List<ResponseUnitDto>> GetAllAsync()
        {
           return await _repository.GetAllAsync();
        }

        public async Task<UpdateUnitDto> UpdateUnitAsync(int id, UpdateUnitDto dto)
        {
            return await _repository.UpdateUnitAsync(id, dto);
        }
    }
}
