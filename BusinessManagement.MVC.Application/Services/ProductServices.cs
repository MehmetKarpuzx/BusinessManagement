using BusinessManagement.MVC.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using BusinessManagement.MVC.DTO.ProductDTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BusinessManagement.MVC.Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ProductServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "Product");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var entities = JsonSerializer.Deserialize<List<ResultProductDto>>(content, options);
                return entities;
            }
            return new List<ResultProductDto>();
        }

        public async Task<AddProductDto> AddProductAsync(AddProductDto addProductDto)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl + "Product", addProductDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<AddProductDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task<UpdateProductDto> UpdateProductAsync(UpdateProductDto updateProductDto, int id)
        {
            var response = await _httpClient.PutAsJsonAsync(_baseUrl + $"Product/{id}", updateProductDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<UpdateProductDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(_baseUrl + $"Product/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
