using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.UserDTOs;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessManagement.MVC.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public UserServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<List<ResultUserDto>> GetAllUsersAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "User/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                return JsonSerializer.Deserialize<List<ResultUserDto>>(content, options) ?? new List<ResultUserDto>();
            }
            return new List<ResultUserDto>();
        }

        public async Task<AddUserDto> AddUserAsync(AddUserDto dto)
        {
            // Map Password -> PasswordHash for the API
            var apiDto = new
            {
                dto.Name,
                dto.Surname,
                dto.Username,
                PasswordHash = dto.Password,
                dto.RolId
            };
            var response = await _httpClient.PostAsJsonAsync(_baseUrl + "User/AddUser", apiDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                return JsonSerializer.Deserialize<AddUserDto>(content, options);
            }
            return null;
        }

        public async Task<UpdateUserDto> UpdateUserAsync(UpdateUserDto dto, int id)
        {
            var apiDto = new
            {
                dto.Name,
                dto.Surname,
                dto.Username,
                PasswordHash = dto.Password ?? "",
                dto.RolId,
                dto.IsActive
            };
            var response = await _httpClient.PutAsJsonAsync(_baseUrl + $"User/UpdateUser/{id}", apiDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                return JsonSerializer.Deserialize<UpdateUserDto>(content, options);
            }
            return null;
        }

        public async Task DeleteUserAsync(int id)
        {
            await _httpClient.DeleteAsync(_baseUrl + $"User/DeleteUser/{id}");
        }
    }
}
