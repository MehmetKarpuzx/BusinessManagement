using BusinessManagement.DTO.CargoCompanyDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Interfaces.Repositories
{
    public interface ICargoCompanyRepository
    {
        Task<List<ResponseCargoCompanyDto>> GetAllCargoCompaniesAsync();
        Task<AddCargoCompanyDto> AddCargoCompanyAsync(AddCargoCompanyDto addCargoCompanyDto);
        Task<UpdateCargoCompanyDto> UpdateCargoCompanyAsync(int id,UpdateCargoCompanyDto updateCargoCompanyDto );
        Task DeleteCargoCompanyAsync(int id);

    }
}
