using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.MaterialProcurementDTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace BusinessManagement.MVC.Application.Services
{
    public class MaterialProcurementServices : IMaterialProcurementServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public MaterialProcurementServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<List<ResultMaterialProcurementDto>> GetAllMaterialProcurementsAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "MaterialProcurement/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var entities = JsonSerializer.Deserialize<List<ResultMaterialProcurementDto>>(content, options);
                return entities;
            }
            return new List<ResultMaterialProcurementDto>();
        }

        public async Task<AddMaterialProcurementDto> AddMaterialProcurementAsync(AddMaterialProcurementDto addMaterialProcurementDto)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl + "MaterialProcurement/AddMaterialProcurement", addMaterialProcurementDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<AddMaterialProcurementDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task<UpdateMaterialProcurementDto> UpdateMaterialProcurementAsync(UpdateMaterialProcurementDto updateMaterialProcurementDto, int id)
        {
            var response = await _httpClient.PutAsJsonAsync(_baseUrl + $"MaterialProcurement/{id}", updateMaterialProcurementDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<UpdateMaterialProcurementDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task DeleteMaterialProcurementAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(_baseUrl + $"MaterialProcurement/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
