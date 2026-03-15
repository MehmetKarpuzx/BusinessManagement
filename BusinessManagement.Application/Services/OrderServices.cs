using BusinessManagement.Application.Interfaces;
using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.DTO.OrderDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.Application.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _repository;
        public OrderServices(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddOrderDto> AddOrderAsync(AddOrderDto dto)
        {
            return await _repository.AddOrderAsync(dto);
        }

        public Task DeleteOrderAsync(int id)
        {
            return _repository.DeleteOrderAsync(id);
        }

        public async Task<List<ResponseOrderDto>> GetAllAsync()
        {
           return await _repository.GetAllAsync();
        }

        public async Task<UpdateOrderDto> UpdateOrderAsync(int id, UpdateOrderDto dto)
        {
            return await _repository.UpdateOrderAsync(id, dto);
        }
    }
}
