using BusinessManagement.Application.Interfaces;
using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.DTO.TransferDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.Application.Services
{
    public class TransferServices : ITransferServices
    {
        private readonly ITransferRepository _repository;
        public TransferServices(ITransferRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddTransferDto> AddTransferAsync(AddTransferDto dto)
        {
            return await _repository.AddTransferAsync(dto);
        }

        public Task DeleteTransferAsync(int id)
        {
            return _repository.DeleteTransferAsync(id);
        }

        public async Task<List<ResponseTransferDto>> GetAllAsync()
        {
           return await _repository.GetAllAsync();
        }

        public async Task<UpdateTransferDto> UpdateTransferAsync(int id, UpdateTransferDto dto)
        {
            return await _repository.UpdateTransferAsync(id, dto);
        }
    }
}
