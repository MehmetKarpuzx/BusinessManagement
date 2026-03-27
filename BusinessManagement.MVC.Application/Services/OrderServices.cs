using BusinessManagement.MVC.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using BusinessManagement.MVC.DTO.OrderDTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BusinessManagement.MVC.Application.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public OrderServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<List<ResultOrderDto>> GetAllOrdersAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "Order/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var entities = JsonSerializer.Deserialize<List<ResultOrderDto>>(content, options);
                return entities;
            }
            return new List<ResultOrderDto>();
        }

        public async Task<AddOrderDto> AddOrderAsync(AddOrderDto addOrderDto)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl + "Order/AddOrder", addOrderDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<AddOrderDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task<UpdateOrderDto> UpdateOrderAsync(UpdateOrderDto updateOrderDto, int id)
        {
            var response = await _httpClient.PutAsJsonAsync(_baseUrl + $"Order/{id}", updateOrderDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<UpdateOrderDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task DeleteOrderAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(_baseUrl + $"Order/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
