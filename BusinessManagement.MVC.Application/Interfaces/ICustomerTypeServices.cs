using BusinessManagement.MVC.DTO.CustomerTypeDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.MVC.Application.Interfaces
{
    public interface ICustomerTypeServices
    {
        Task<List<ResultCustomerTypeDto>> GetAllCustomerTypesAsync();
        Task<AddCustomerTypeDto> AddCustomerTypeAsync(AddCustomerTypeDto addCustomerTypeDto);
        Task<UpdateCustomerTypeDto> UpdateCustomerTypeAsync(UpdateCustomerTypeDto updateCustomerTypeDto, int id);
        Task DeleteCustomerTypeAsync(int id);
    }
}
