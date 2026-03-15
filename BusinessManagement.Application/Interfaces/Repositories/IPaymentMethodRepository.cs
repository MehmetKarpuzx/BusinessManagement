using BusinessManagement.DTO.PaymentMethodDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Interfaces.Repositories
{
    public interface IPaymentMethodRepository
    {
        Task<List<ResponsePaymentMethodDto>> GetAllAsync();
        Task<AddPaymentMethodDto> AddPaymentMethodAsync(AddPaymentMethodDto paymentMethodDto);
        Task<UpdatePaymentMethodDto> UpdatePaymentMethodAsync(int id, UpdatePaymentMethodDto paymentMethodDto);
        Task DeletePaymentMethodAsync(int id);
    }
}
