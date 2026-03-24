using BusinessManagement.MVC.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using BusinessManagement.MVC.DTO.TransferDTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BusinessManagement.MVC.Application.Services
{
    public class TransferServices : ITransferServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public TransferServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<List<ResultTransferDto>> GetAllTransfersAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "Transfer");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var entities = JsonSerializer.Deserialize<List<ResultTransferDto>>(content, options);
                return entities;
            }
            return new List<ResultTransferDto>();
        }

        public async Task<AddTransferDto> AddTransferAsync(AddTransferDto addTransferDto)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl + "Transfer", addTransferDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<AddTransferDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task<UpdateTransferDto> UpdateTransferAsync(UpdateTransferDto updateTransferDto, int id)
        {
            var response = await _httpClient.PutAsJsonAsync(_baseUrl + $"Transfer/{id}", updateTransferDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<UpdateTransferDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task DeleteTransferAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(_baseUrl + $"Transfer/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
