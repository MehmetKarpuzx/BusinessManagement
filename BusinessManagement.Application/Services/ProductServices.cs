using BusinessManagement.Application.Interfaces;
using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.DTO.ProductDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _repository;
        public ProductServices(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddProductDto> AddProductAsync(AddProductDto dto)
        {
            return await _repository.AddProductAsync(dto);
        }

        public Task DeleteProductAsync(int id)
        {
            return _repository.DeleteProductAsync(id);
        }

        public async Task<List<ResponseProductDto>> GetAllAsync()
        {
           return await _repository.GetAllAsync();
        }

        public async Task<UpdateProductDto> UpdateProductAsync(int id, UpdateProductDto dto)
        {
            return await _repository.UpdateProductAsync(id, dto);
        }
    }
}
