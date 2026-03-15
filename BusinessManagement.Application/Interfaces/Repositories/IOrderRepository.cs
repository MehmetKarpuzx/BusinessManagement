using BusinessManagement.DTO.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<List<ResponseOrderDto>> GetAllAsync();
        Task<AddOrderDto> AddOrderAsync(AddOrderDto orderDto);
        Task<UpdateOrderDto> UpdateOrderAsync(int id, UpdateOrderDto orderDto);
        Task DeleteOrderAsync(int id);
    }
}
