using BusinessManagement.MVC.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using BusinessManagement.MVC.DTO.PaymentDTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BusinessManagement.MVC.Application.Services
{
    public class PaymentServices : IPaymentServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public PaymentServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<List<ResultPaymentDto>> GetAllPaymentsAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "Payment/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var entities = JsonSerializer.Deserialize<List<ResultPaymentDto>>(content, options);
                return entities;
            }
            return new List<ResultPaymentDto>();
        }

        public async Task<AddPaymentDto> AddPaymentAsync(AddPaymentDto addPaymentDto)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl + "Payment/AddPayment", addPaymentDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<AddPaymentDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task<UpdatePaymentDto> UpdatePaymentAsync(UpdatePaymentDto updatePaymentDto, int id)
        {
            var response = await _httpClient.PutAsJsonAsync(_baseUrl + $"Payment/{id}", updatePaymentDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<UpdatePaymentDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task DeletePaymentAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(_baseUrl + $"Payment/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
