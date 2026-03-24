using BusinessManagement.MVC.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using BusinessManagement.MVC.DTO.BranchDTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace BusinessManagement.MVC.Application.Services
{
    public class BranchServices : IBranchServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public BranchServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<List<ResultBranchDto>> GetAllBranchesAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "Branch");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var branches = JsonSerializer.Deserialize<List<ResultBranchDto>>(content, options);
                return branches;
            }
            return new List<ResultBranchDto>();
        }

        public async Task<AddBranchDto> AddBranchAsync(AddBranchDto addBranchDto)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl + "Branch", addBranchDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<AddBranchDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task<UpdateBranchDto> UpdateBranchAsync(UpdateBranchDto updateBranchDto, int id)
        {
            var response = await _httpClient.PutAsJsonAsync(_baseUrl + $"Branch/{id}", updateBranchDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<UpdateBranchDto>(content, options);
                return result;
            }
            return null;
        }

        public async Task DeleteBranchAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(_baseUrl + $"Branch/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
