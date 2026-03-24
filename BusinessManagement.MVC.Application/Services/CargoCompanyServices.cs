using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.CargoCompanyDTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace BusinessManagement.MVC.Application.Services
{
    public class CargoCompanyServices : ICargoCompanyServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public CargoCompanyServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<List<ResultCargoCompanyDto>> GetAllCargoCompaniesAsync()
        {
            
            var response = await _httpClient.GetAsync(_baseUrl + "CargoCompany");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var entities = JsonSerializer.Deserialize<List<ResultCargoCompanyDto>>(content, options);
                return entities;
            }
            return new List<ResultCargoCompanyDto>();
        }

        public async Task<AddCargoCompanyDto> AddCargoCompanyAsync(AddCargoCompanyDto addCargoCompanyDto)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl + "CargoCompany", addCargoCompanyDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<AddCargoCompanyDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task<UpdateCargoCompanyDto> UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto, int id)
        {
            var response = await _httpClient.PutAsJsonAsync(_baseUrl + $"CargoCompany/{id}", updateCargoCompanyDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<UpdateCargoCompanyDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task DeleteCargoCompanyAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(_baseUrl + $"CargoCompany/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
