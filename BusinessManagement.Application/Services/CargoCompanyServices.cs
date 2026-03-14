using BusinessManagement.Application.Interfaces;
using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.Domain.Entities;
using BusinessManagement.DTO.CargoCompanyDTOs;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace BusinessManagement.Application.Services
{
    public class CargoCompanyServices : ICargoCompanyServices
    {
        private readonly ICargoCompanyRepository _cargoCompanyRepository;
        public CargoCompanyServices(ICargoCompanyRepository cargoCompanyRepository)
        {
            _cargoCompanyRepository = cargoCompanyRepository;
        }
        public async Task<AddCargoCompanyDto> AddCargoCompanyAsync(AddCargoCompanyDto addCargoCompanyDto)
        {
            return await _cargoCompanyRepository.AddCargoCompanyAsync(addCargoCompanyDto);
        }

        public Task DeleteCargoCompanyAsync(int id)
        {
            return _cargoCompanyRepository.DeleteCargoCompanyAsync(id);
        }

        public async Task<List<ResponseCargoCompanyDto>> GetAllCargoCompaniesAsync()
        {
            return await _cargoCompanyRepository.GetAllCargoCompaniesAsync();
        }

        public async Task<UpdateCargoCompanyDto> UpdateCargoCompanyAsync(int id, UpdateCargoCompanyDto updateCargoCompanyDto)
        {
           return await _cargoCompanyRepository.UpdateCargoCompanyAsync(id, updateCargoCompanyDto);
        }
    }
}
