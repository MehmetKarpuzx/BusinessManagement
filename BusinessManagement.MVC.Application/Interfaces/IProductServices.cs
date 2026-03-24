using BusinessManagement.MVC.DTO.ProductDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.MVC.Application.Interfaces
{
    public interface IProductServices
    {
        Task<List<ResultProductDto>> GetAllProductsAsync();
        Task<AddProductDto> AddProductAsync(AddProductDto addProductDto);
        Task<UpdateProductDto> UpdateProductAsync(UpdateProductDto updateProductDto, int id);
        Task DeleteProductAsync(int id);
    }
}
