using BusinessManagement.Application.Interfaces;
using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.DTO.PaymentDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.Application.Services
{
    public class PaymentServices : IPaymentServices
    {
        private readonly IPaymentRepository _repository;
        public PaymentServices(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddPaymentDto> AddPaymentAsync(AddPaymentDto dto)
        {
            return await _repository.AddPaymentAsync(dto);
        }

        public Task DeletePaymentAsync(int id)
        {
            return _repository.DeletePaymentAsync(id);
        }

        public async Task<List<ResponsePaymentDto>> GetAllAsync()
        {
           return await _repository.GetAllAsync();
        }

        public async Task<UpdatePaymentDto> UpdatePaymentAsync(int id, UpdatePaymentDto dto)
        {
            return await _repository.UpdatePaymentAsync(id, dto);
        }
    }
}
