using BusinessManagement.MVC.DTO.ProcessTypeDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.MVC.Application.Interfaces
{
    public interface IProcessTypeServices
    {
        Task<List<ResultProcessTypeDto>> GetAllProcessTypesAsync();
        Task<AddProcessTypeDto> AddProcessTypeAsync(AddProcessTypeDto addProcessTypeDto);
        Task<UpdateProcessTypeDto> UpdateProcessTypeAsync(UpdateProcessTypeDto updateProcessTypeDto, int id);
        Task DeleteProcessTypeAsync(int id);
    }
}
