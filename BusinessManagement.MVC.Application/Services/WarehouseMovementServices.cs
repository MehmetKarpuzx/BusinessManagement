using BusinessManagement.MVC.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using BusinessManagement.MVC.DTO.WarehouseMovementDTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BusinessManagement.MVC.Application.Services
{
    public class WarehouseMovementServices : IWarehouseMovementServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public WarehouseMovementServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<List<ResultWarehouseMovementDto>> GetAllWarehouseMovementsAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "WarehouseMovement/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var entities = JsonSerializer.Deserialize<List<ResultWarehouseMovementDto>>(content, options);
                return entities;
            }
            return new List<ResultWarehouseMovementDto>();
        }

        public async Task<AddWarehouseMovementDto> AddWarehouseMovementAsync(AddWarehouseMovementDto addWarehouseMovementDto)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl + "WarehouseMovement/AddWarehouseMovement", addWarehouseMovementDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<AddWarehouseMovementDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task<UpdateWarehouseMovementDto> UpdateWarehouseMovementAsync(UpdateWarehouseMovementDto updateWarehouseMovementDto, int id)
        {
            var response = await _httpClient.PutAsJsonAsync(_baseUrl + $"WarehouseMovement/{id}", updateWarehouseMovementDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<UpdateWarehouseMovementDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task DeleteWarehouseMovementAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(_baseUrl + $"WarehouseMovement/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
