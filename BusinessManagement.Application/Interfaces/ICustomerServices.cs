using BusinessManagement.DTO.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Interfaces
{
    public interface ICustomerServices
    {
        Task<List<ResponseCustomerDto>> GetAllAsync();
        Task<AddCustomerDto> AddAsync(AddCustomerDto addCustomerDto);
        Task<UpdateCustomerDto> UpdateAsync(int id, UpdateCustomerDto updateCustomerDto);
        Task DeleteAsync(int id);

    }
}
