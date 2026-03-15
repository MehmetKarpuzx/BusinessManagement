using BusinessManagement.Application.Interfaces;
using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.DTO.CustomerDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.Application.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _repository;
        public CustomerServices(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddCustomerDto> AddAsync(AddCustomerDto dto)
        {
            return await _repository.AddAsync(dto);
        }

        public Task DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public async Task<List<ResponseCustomerDto>> GetAllAsync()
        {
           return await _repository.GetAllAsync();
        }

        public async Task<UpdateCustomerDto> UpdateAsync(int id, UpdateCustomerDto dto)
        {
            return await _repository.UpdateAsync(id, dto);
        }
    }
}
