using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.CustomerTypeDTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace BusinessManagement.MVC.Application.Services
{
    public class CustomerTypeServices : ICustomerTypeServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public CustomerTypeServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<List<ResultCustomerTypeDto>> GetAllCustomerTypesAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "CustomerType");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var entities = JsonSerializer.Deserialize<List<ResultCustomerTypeDto>>(content, options);
                return entities;
            }
            return new List<ResultCustomerTypeDto>();
        }

        public async Task<AddCustomerTypeDto> AddCustomerTypeAsync(AddCustomerTypeDto addCustomerTypeDto)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl + "CustomerType", addCustomerTypeDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<AddCustomerTypeDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task<UpdateCustomerTypeDto> UpdateCustomerTypeAsync(UpdateCustomerTypeDto updateCustomerTypeDto, int id)
        {
            var response = await _httpClient.PutAsJsonAsync(_baseUrl + $"CustomerType/{id}", updateCustomerTypeDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<UpdateCustomerTypeDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task DeleteCustomerTypeAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(_baseUrl + $"CustomerType/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
