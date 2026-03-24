using BusinessManagement.MVC.DTO.OrderDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.MVC.Application.Interfaces
{
    public interface IOrderServices
    {
        Task<List<ResultOrderDto>> GetAllOrdersAsync();
        Task<AddOrderDto> AddOrderAsync(AddOrderDto addOrderDto);
        Task<UpdateOrderDto> UpdateOrderAsync(UpdateOrderDto updateOrderDto, int id);
        Task DeleteOrderAsync(int id);
    }
}
