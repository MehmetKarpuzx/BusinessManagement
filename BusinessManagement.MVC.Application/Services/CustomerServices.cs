using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.CustomerDTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace BusinessManagement.MVC.Application.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public CustomerServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<List<ResultCustomerDto>> GetAllCustomersAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "Customer/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var entities = JsonSerializer.Deserialize<List<ResultCustomerDto>>(content, options);
                return entities;
            }
            return new List<ResultCustomerDto>();
        }

        public async Task<AddCustomerDto> AddCustomerAsync(AddCustomerDto addCustomerDto)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl + "Customer/AddCustomer", addCustomerDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<AddCustomerDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task<UpdateCustomerDto> UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto, int id)
        {
            var response = await _httpClient.PutAsJsonAsync(_baseUrl + $"Customer/{id}", updateCustomerDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<UpdateCustomerDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(_baseUrl + $"Customer/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
