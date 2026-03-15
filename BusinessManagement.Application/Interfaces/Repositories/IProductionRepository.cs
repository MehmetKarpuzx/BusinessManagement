using BusinessManagement.DTO.ProductionDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Interfaces.Repositories
{
    public interface IProductionRepository
    {
        Task<List<ResponseProductionDto>> GetAllAsync();
        Task<AddProductionDto> AddProductionAsync(AddProductionDto productionDto);
        Task<UpdateProductionDto> UpdateProductionAsync(int id, UpdateProductionDto productionDto);
        Task DeleteProductionAsync(int id);
    }
}
