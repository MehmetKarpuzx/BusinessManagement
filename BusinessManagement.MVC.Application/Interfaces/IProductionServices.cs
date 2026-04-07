using BusinessManagement.MVC.DTO.ProductionDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.MVC.Application.Interfaces
{
    public interface IProductionServices
    {
        Task<List<ResultProductionDto>> GetAllProductionsAsync();
        Task<AddProductionDto> AddProductionAsync(AddProductionDto addProductionDto);
        Task<UpdateProductionDto> UpdateProductionAsync(UpdateProductionDto updateProductionDto, int id);
        Task DeleteProductionAsync(int id);
    }
}
