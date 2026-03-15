using BusinessManagement.Application.Interfaces;
using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.DTO.CustomerTypeDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.Application.Services
{
    public class CustomerTypeServices : ICustomerTypeServices
    {
        private readonly ICustomerTypeRepository _repository;
        public CustomerTypeServices(ICustomerTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddCustomerTypeDto> AddCustomerTypeAsync(AddCustomerTypeDto dto)
        {
            return await _repository.AddCustomerTypeAsync(dto);
        }

        public Task DeleteCustomerTypeAsync(int id)
        {
            return _repository.DeleteCustomerTypeAsync(id);
        }

        public async Task<List<ResponseCustomerTypeDto>> GetAllAsync()
        {
           return await _repository.GetAllAsync();
        }

        public async Task<UpdateCustomerTypeDto> UpdateCustomerTypeAsync(int id, UpdateCustomerTypeDto dto)
        {
            return await _repository.UpdateCustomerTypeAsync(id, dto);
        }
    }
}
