using BusinessManagement.DTO.CargoCompanyDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Interfaces
{
    public interface ICargoCompanyServices
    {
        Task<AddCargoCompanyDto> AddCargoCompanyAsync(AddCargoCompanyDto addCargoCompanyDto);
        Task<List<ResponseCargoCompanyDto>> GetAllCargoCompaniesAsync();
        Task DeleteCargoCompanyAsync(int id);
        Task<UpdateCargoCompanyDto> UpdateCargoCompanyAsync(int id, UpdateCargoCompanyDto updateCargoCompanyDto);
    }
}
