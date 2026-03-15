using BusinessManagement.DTO.PaymentMethodDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Interfaces
{
    public interface IPaymentMethodServices
    {
        Task<List<ResponsePaymentMethodDto>> GetAllAsync();
        Task<AddPaymentMethodDto> AddPaymentMethodAsync(AddPaymentMethodDto paymentMethodDto);
        Task<UpdatePaymentMethodDto> UpdatePaymentMethodAsync(int id, UpdatePaymentMethodDto paymentMethodDto);
        Task DeletePaymentMethodAsync(int id);
    }
}
