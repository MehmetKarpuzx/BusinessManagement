using BusinessManagement.Application.Interfaces;
using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.DTO.ProductionDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.Application.Services
{
    public class ProductionServices : IProductionServices
    {
        private readonly IProductionRepository _repository;
        public ProductionServices(IProductionRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddProductionDto> AddProductionAsync(AddProductionDto dto)
        {
            return await _repository.AddProductionAsync(dto);
        }

        public Task DeleteProductionAsync(int id)
        {
            return _repository.DeleteProductionAsync(id);
        }

        public async Task<List<ResponseProductionDto>> GetAllAsync()
        {
           return await _repository.GetAllAsync();
        }

        public async Task<UpdateProductionDto> UpdateProductionAsync(int id, UpdateProductionDto dto)
        {
            return await _repository.UpdateProductionAsync(id, dto);
        }
    }
}
