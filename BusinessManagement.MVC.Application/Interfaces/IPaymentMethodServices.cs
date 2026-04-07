using BusinessManagement.MVC.DTO.PaymentMethodDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.MVC.Application.Interfaces
{
    public interface IPaymentMethodServices
    {
        Task<List<ResultPaymentMethodDto>> GetAllPaymentMethodsAsync();
        Task<AddPaymentMethodDto> AddPaymentMethodAsync(AddPaymentMethodDto addPaymentMethodDto);
        Task<UpdatePaymentMethodDto> UpdatePaymentMethodAsync(UpdatePaymentMethodDto updatePaymentMethodDto, int id);
        Task DeletePaymentMethodAsync(int id);
    }
}
