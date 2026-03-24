using BusinessManagement.MVC.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using BusinessManagement.MVC.DTO.SupplierDTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BusinessManagement.MVC.Application.Services
{
    public class SupplierServices : ISupplierServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public SupplierServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<List<ResultSupplierDto>> GetAllSuppliersAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "Supplier");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var entities = JsonSerializer.Deserialize<List<ResultSupplierDto>>(content, options);
                return entities;
            }
            return new List<ResultSupplierDto>();
        }

        public async Task<AddSupplierDto> AddSupplierAsync(AddSupplierDto addSupplierDto)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl + "Supplier", addSupplierDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<AddSupplierDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task<UpdateSupplierDto> UpdateSupplierAsync(UpdateSupplierDto updateSupplierDto, int id)
        {
            var response = await _httpClient.PutAsJsonAsync(_baseUrl + $"Supplier/{id}", updateSupplierDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<UpdateSupplierDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task DeleteSupplierAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(_baseUrl + $"Supplier/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
