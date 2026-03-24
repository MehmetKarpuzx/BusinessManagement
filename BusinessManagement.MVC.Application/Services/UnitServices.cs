using BusinessManagement.MVC.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using BusinessManagement.MVC.DTO.UnitDTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BusinessManagement.MVC.Application.Services
{
    public class UnitServices : IUnitServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public UnitServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<List<ResultUnitDto>> GetAllUnitsAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "Unit");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var entities = JsonSerializer.Deserialize<List<ResultUnitDto>>(content, options);
                return entities;
            }
            return new List<ResultUnitDto>();
        }

        public async Task<AddUnitDto> AddUnitAsync(AddUnitDto addUnitDto)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl + "Unit", addUnitDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<AddUnitDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task<UpdateUnitDto> UpdateUnitAsync(UpdateUnitDto updateUnitDto, int id)
        {
            var response = await _httpClient.PutAsJsonAsync(_baseUrl + $"Unit/{id}", updateUnitDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<UpdateUnitDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task DeleteUnitAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(_baseUrl + $"Unit/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
