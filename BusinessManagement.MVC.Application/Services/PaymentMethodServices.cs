using BusinessManagement.MVC.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using BusinessManagement.MVC.DTO.PaymentMethodDTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BusinessManagement.MVC.Application.Services
{
    public class PaymentMethodServices : IPaymentMethodServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public PaymentMethodServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<List<ResultPaymentMethodDto>> GetAllPaymentMethodsAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "PaymentMethod");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var entities = JsonSerializer.Deserialize<List<ResultPaymentMethodDto>>(content, options);
                return entities;
            }
            return new List<ResultPaymentMethodDto>();
        }

        public async Task<AddPaymentMethodDto> AddPaymentMethodAsync(AddPaymentMethodDto addPaymentMethodDto)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl + "PaymentMethod", addPaymentMethodDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<AddPaymentMethodDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task<UpdatePaymentMethodDto> UpdatePaymentMethodAsync(UpdatePaymentMethodDto updatePaymentMethodDto, int id)
        {
            var response = await _httpClient.PutAsJsonAsync(_baseUrl + $"PaymentMethod/{id}", updatePaymentMethodDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<UpdatePaymentMethodDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task DeletePaymentMethodAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(_baseUrl + $"PaymentMethod/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
