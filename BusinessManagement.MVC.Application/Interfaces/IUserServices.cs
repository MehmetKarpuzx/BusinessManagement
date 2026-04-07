using BusinessManagement.MVC.DTO.UserDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.MVC.Application.Interfaces
{
    public interface IUserServices
    {
        Task<List<ResultUserDto>> GetAllUsersAsync();
        Task<AddUserDto> AddUserAsync(AddUserDto dto);
        Task<UpdateUserDto> UpdateUserAsync(UpdateUserDto dto, int id);
        Task DeleteUserAsync(int id);
    }
}
