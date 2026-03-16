using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.BranchDTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BusinessManagement.MVC.Application.Services
{
    public class BranchServices : IBranchServices
    {
        private readonly HttpClient _httpClient;

        public BranchServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultBranchDto>> GetAllBranchesAsync()
        {
            var response = await _httpClient.GetAsync("Branch");
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
            var response = await _httpClient.PostAsJsonAsync("Branch", addBranchDto);
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
            var response = await _httpClient.PutAsJsonAsync($"Branch/{id}", updateBranchDto);
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
            var response = await _httpClient.DeleteAsync($"api/v1/Branch/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
