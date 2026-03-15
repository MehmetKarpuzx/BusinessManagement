using BusinessManagement.DTO.PaymentDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Interfaces.Repositories
{
    public interface IPaymentRepository
    {
        Task<List<ResponsePaymentDto>> GetAllAsync();   
        Task<AddPaymentDto> AddPaymentAsync(AddPaymentDto paymentDto);
        Task<UpdatePaymentDto> UpdatePaymentAsync(int id, UpdatePaymentDto paymentDto);
        Task DeletePaymentAsync(int id);
    }
}
