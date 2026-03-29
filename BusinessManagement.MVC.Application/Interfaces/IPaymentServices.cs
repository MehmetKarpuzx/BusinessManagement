using BusinessManagement.MVC.DTO.PaymentDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.MVC.Application.Interfaces
{
    public interface IPaymentServices
    {
        Task<List<ResultPaymentDto>> GetAllPaymentsAsync();
        Task<AddPaymentDto> AddPaymentAsync(AddPaymentDto addPaymentDto);
        Task<UpdatePaymentDto> UpdatePaymentAsync(UpdatePaymentDto updatePaymentDto, int id);
        Task DeletePaymentAsync(int id);
    }
}
