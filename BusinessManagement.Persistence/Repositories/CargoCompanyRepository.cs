using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.Domain.Entities;
using BusinessManagement.DTO.CargoCompanyDTOs;
using BusinessManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Persistence.Repositories
{
    public class CargoCompanyRepository :ICargoCompanyRepository
    {
        private readonly BusinessManagementDbContext _context;
        public CargoCompanyRepository(BusinessManagementDbContext context)
        {
            _context = context;
        }

        public async Task<AddCargoCompanyDto> AddCargoCompanyAsync(AddCargoCompanyDto addCargoCompanyDto)
        {
            var cargoCompany = new CargoCompany
            {
                Name = addCargoCompanyDto.Name,
                Description = addCargoCompanyDto.Description,
                CreateDate = addCargoCompanyDto.CreateDate,
                IsDeleted = addCargoCompanyDto.IsDeleted
            };
            _context.CargoCompanies.Add(cargoCompany);
            await _context.SaveChangesAsync();
            return addCargoCompanyDto;

        }

        public  Task DeleteCargoCompanyAsync(int id)
        {
            var cargoCompany = _context.CargoCompanies.Find(id);
            if (cargoCompany == null || cargoCompany.IsDeleted)
            {
                throw new KeyNotFoundException($"Kargo şirketi bulunamadı Kargo Şirketi ID = {id}  (404)");
            }
            cargoCompany.IsDeleted = true;
            _context.SaveChangesAsync();
            return Task.CompletedTask;

        }

        public async Task<List<ResponseCargoCompanyDto>> GetAllCargoCompaniesAsync()
        {
            var cargoCompanies = _context.CargoCompanies
                .Where(c => !c.IsDeleted)
                .Select(c => new ResponseCargoCompanyDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    CreateDate = c.CreateDate
                }).ToListAsync();
            return await cargoCompanies;

        }

        public async Task<UpdateCargoCompanyDto> UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto, int id)
        {
            var cargoCompany = _context.CargoCompanies.Find(id);
            if (cargoCompany == null || cargoCompany.IsDeleted)
            {
                throw new KeyNotFoundException($"Kargo şirketi bulunamadı Kargo Şirketi ID = {id}  (404)");
            }
            var cargCompany = new CargoCompany
            {
                Id = id,
                Name = updateCargoCompanyDto.Name,
                Description = updateCargoCompanyDto.Description,
                CreateDate = cargoCompany.CreateDate,
                IsDeleted = cargoCompany.IsDeleted
            };
            _context.Entry(cargoCompany).CurrentValues.SetValues(cargCompany);
            await _context.SaveChangesAsync();
            return updateCargoCompanyDto;
        }
    }
}
