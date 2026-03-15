using BusinessManagement.DTO.ProcessTypeDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Interfaces.Repositories
{
    public interface IProcessTypeRepository
    {
        Task<List<ResponseProcessTypeDto>> GetAllAsync();
        Task<AddProcessTypeDto> AddProcessTypeAsync(AddProcessTypeDto processTypeDto);
        Task<UpdateProcessTypeDto> UpdateProcessTypeAsync(int id, UpdateProcessTypeDto processTypeDto);
        Task DeleteProcessTypeAsync(int id);
    }
}
