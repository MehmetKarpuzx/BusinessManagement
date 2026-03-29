using BusinessManagement.MVC.DTO.CustomerDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.MVC.Application.Interfaces
{
    public interface ICustomerServices
    {
        Task<List<ResultCustomerDto>> GetAllCustomersAsync();
        Task<AddCustomerDto> AddCustomerAsync(AddCustomerDto addCustomerDto);
        Task<UpdateCustomerDto> UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto, int id);
        Task DeleteCustomerAsync(int id);
    }
}
