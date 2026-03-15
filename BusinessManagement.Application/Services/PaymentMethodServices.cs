using BusinessManagement.Application.Interfaces;
using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.DTO.PaymentMethodDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.Application.Services
{
    public class PaymentMethodServices : IPaymentMethodServices
    {
        private readonly IPaymentMethodRepository _repository;
        public PaymentMethodServices(IPaymentMethodRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddPaymentMethodDto> AddPaymentMethodAsync(AddPaymentMethodDto dto)
        {
            return await _repository.AddPaymentMethodAsync(dto);
        }

        public Task DeletePaymentMethodAsync(int id)
        {
            return _repository.DeletePaymentMethodAsync(id);
        }

        public async Task<List<ResponsePaymentMethodDto>> GetAllAsync()
        {
           return await _repository.GetAllAsync();
        }

        public async Task<UpdatePaymentMethodDto> UpdatePaymentMethodAsync(int id, UpdatePaymentMethodDto dto)
        {
            return await _repository.UpdatePaymentMethodAsync(id, dto);
        }
    }
}
