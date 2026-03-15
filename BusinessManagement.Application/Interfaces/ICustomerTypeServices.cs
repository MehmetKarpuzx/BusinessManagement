using BusinessManagement.DTO.CustomerTypeDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Interfaces
{
    public interface ICustomerTypeServices
    {
        Task<List<ResponseCustomerTypeDto>> GetAllAsync();
        Task<AddCustomerTypeDto> AddCustomerTypeAsync(AddCustomerTypeDto customerType);
        Task<UpdateCustomerTypeDto> UpdateCustomerTypeAsync(int id, UpdateCustomerTypeDto customerType);
        Task DeleteCustomerTypeAsync(int id);
    }
}
