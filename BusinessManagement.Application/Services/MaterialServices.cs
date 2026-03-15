using BusinessManagement.Application.Interfaces;
using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.DTO.MaterialDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.Application.Services
{
    public class MaterialServices : IMaterialServices
    {
        private readonly IMaterialRepository _repository;
        public MaterialServices(IMaterialRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddMaterialDto> AddMaterialAsync(AddMaterialDto dto)
        {
            return await _repository.AddMaterialAsync(dto);
        }

        public Task DeleteMaterialAsync(int id)
        {
            return _repository.DeleteMaterialAsync(id);
        }

        public async Task<List<ResponseMaterialDto>> GetAllAsync()
        {
           return await _repository.GetAllAsync();
        }

        public async Task<UpdateMaterialDto> UpdateMaterialAsync(int id, UpdateMaterialDto dto)
        {
            return await _repository.UpdateMaterialAsync(id, dto);
        }
    }
}
