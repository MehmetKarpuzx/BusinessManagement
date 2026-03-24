using BusinessManagement.MVC.DTO.CargoCompanyDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.MVC.Application.Interfaces
{
    public interface ICargoCompanyServices
    {
        Task<List<ResultCargoCompanyDto>> GetAllCargoCompaniesAsync();
        Task<AddCargoCompanyDto> AddCargoCompanyAsync(AddCargoCompanyDto addCargoCompanyDto);
        Task<UpdateCargoCompanyDto> UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto, int id);
        Task DeleteCargoCompanyAsync(int id);
    }
}
