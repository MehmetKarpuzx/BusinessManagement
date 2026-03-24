using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.MaterialDTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;

namespace BusinessManagement.MVC.Application.Services
{
    public class MaterialServices : IMaterialServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public MaterialServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<List<ResultMaterialDto>> GetAllMaterialsAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "Material");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var entities = JsonSerializer.Deserialize<List<ResultMaterialDto>>(content, options);
                return entities;
            }
            return new List<ResultMaterialDto>();
        }

        public async Task<AddMaterialDto> AddMaterialAsync(AddMaterialDto addMaterialDto)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl + "Material", addMaterialDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<AddMaterialDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task<UpdateMaterialDto> UpdateMaterialAsync(UpdateMaterialDto updateMaterialDto, int id)
        {
            var response = await _httpClient.PutAsJsonAsync(_baseUrl + $"Material/{id}", updateMaterialDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<UpdateMaterialDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task DeleteMaterialAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(_baseUrl + $"Material/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
