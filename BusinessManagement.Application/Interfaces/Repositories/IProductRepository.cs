using BusinessManagement.DTO.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<ResponseProductDto>> GetAllAsync();
        Task<AddProductDto> AddProductAsync(AddProductDto productDto);
        Task<UpdateProductDto> UpdateProductAsync(int id, UpdateProductDto productDto);
        Task DeleteProductAsync(int id);
    }
}
