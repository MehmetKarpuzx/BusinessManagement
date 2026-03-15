using BusinessManagement.DTO.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Interfaces
{
    public interface IOrderServices
    {
        Task<List<ResponseOrderDto>> GetAllAsync();
        Task<AddOrderDto> AddOrderAsync(AddOrderDto orderDto);
        Task<UpdateOrderDto> UpdateOrderAsync(int id, UpdateOrderDto orderDto);
        Task DeleteOrderAsync(int id);
    }
}
