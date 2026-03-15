using BusinessManagement.Application.Interfaces;
using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.DTO.MaterialProcurementDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.Application.Services
{
    public class MaterialProcurementServices : IMaterialProcurementServices
    {
        private readonly IMaterialProcurementRepository _repository;
        public MaterialProcurementServices(IMaterialProcurementRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddMaterialProcurementDto> AddMaterialProcurementAsync(AddMaterialProcurementDto dto)
        {
            return await _repository.AddMaterialProcurementAsync(dto);
        }

        public Task DeleteMaterialProcurementAsync(int id)
        {
            return _repository.DeleteMaterialProcurementAsync(id);
        }

        public async Task<List<ResponseMaterialProcurementDto>> GetAllAsync()
        {
           return await _repository.GetAllAsync();
        }

        public async Task<UpdateMaterialProcurementDto> UpdateMaterialProcurementAsync(int id, UpdateMaterialProcurementDto dto)
        {
            return await _repository.UpdateMaterialProcurementAsync(id, dto);
        }
    }
}
