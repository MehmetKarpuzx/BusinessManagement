using BusinessManagement.Application.Interfaces;
using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.DTO.ProcessTypeDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.Application.Services
{
    public class ProcessTypeServices : IProcessTypeServices
    {
        private readonly IProcessTypeRepository _repository;
        public ProcessTypeServices(IProcessTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddProcessTypeDto> AddProcessTypeAsync(AddProcessTypeDto dto)
        {
            return await _repository.AddProcessTypeAsync(dto);
        }

        public Task DeleteProcessTypeAsync(int id)
        {
            return _repository.DeleteProcessTypeAsync(id);
        }

        public async Task<List<ResponseProcessTypeDto>> GetAllAsync()
        {
           return await _repository.GetAllAsync();
        }

        public async Task<UpdateProcessTypeDto> UpdateProcessTypeAsync(int id, UpdateProcessTypeDto dto)
        {
            return await _repository.UpdateProcessTypeAsync(id, dto);
        }
    }
}
