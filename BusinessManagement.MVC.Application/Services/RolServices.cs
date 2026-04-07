using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.RolDTOs;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessManagement.MVC.Application.Services
{
    public class RolServices : IRolServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public RolServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<List<ResultRolDto>> GetAllRolsAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "Rol/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                return JsonSerializer.Deserialize<List<ResultRolDto>>(content, options) ?? new List<ResultRolDto>();
            }
            return new List<ResultRolDto>();
        }

        public async Task<AddRolDto> AddRolAsync(AddRolDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl + "Rol/AddRol", dto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                return JsonSerializer.Deserialize<AddRolDto>(content, options);
            }
            return null;
        }

        public async Task<UpdateRolDto> UpdateRolAsync(UpdateRolDto dto, int id)
        {
            var response = await _httpClient.PutAsJsonAsync(_baseUrl + $"Rol/UpdateRol/{id}", dto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                return JsonSerializer.Deserialize<UpdateRolDto>(content, options);
            }
            return null;
        }

        public async Task DeleteRolAsync(int id)
        {
            await _httpClient.DeleteAsync(_baseUrl + $"Rol/DeleteRol/{id}");
        }
    }
}
