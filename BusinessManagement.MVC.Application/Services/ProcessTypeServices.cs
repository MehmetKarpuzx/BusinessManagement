using BusinessManagement.MVC.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using BusinessManagement.MVC.DTO.ProcessTypeDTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BusinessManagement.MVC.Application.Services
{
    public class ProcessTypeServices : IProcessTypeServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ProcessTypeServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<List<ResultProcessTypeDto>> GetAllProcessTypesAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "ProcessType/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var entities = JsonSerializer.Deserialize<List<ResultProcessTypeDto>>(content, options);
                return entities;
            }
            return new List<ResultProcessTypeDto>();
        }

        public async Task<AddProcessTypeDto> AddProcessTypeAsync(AddProcessTypeDto addProcessTypeDto)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl + "ProcessType/AddProcessType", addProcessTypeDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<AddProcessTypeDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task<UpdateProcessTypeDto> UpdateProcessTypeAsync(UpdateProcessTypeDto updateProcessTypeDto, int id)
        {
            var response = await _httpClient.PutAsJsonAsync(_baseUrl + $"ProcessType/{id}", updateProcessTypeDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<UpdateProcessTypeDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task DeleteProcessTypeAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(_baseUrl + $"ProcessType/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
