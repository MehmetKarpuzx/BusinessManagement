using BusinessManagement.MVC.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using BusinessManagement.MVC.DTO.ProductionDTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BusinessManagement.MVC.Application.Services
{
    public class ProductionServices : IProductionServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ProductionServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<List<ResultProductionDto>> GetAllProductionsAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "Production");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var entities = JsonSerializer.Deserialize<List<ResultProductionDto>>(content, options);
                return entities;
            }
            return new List<ResultProductionDto>();
        }

        public async Task<AddProductionDto> AddProductionAsync(AddProductionDto addProductionDto)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl + "Production", addProductionDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<AddProductionDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task<UpdateProductionDto> UpdateProductionAsync(UpdateProductionDto updateProductionDto, int id)
        {
            var response = await _httpClient.PutAsJsonAsync(_baseUrl + $"Production/{id}", updateProductionDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<UpdateProductionDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task DeleteProductionAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(_baseUrl + $"Production/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
