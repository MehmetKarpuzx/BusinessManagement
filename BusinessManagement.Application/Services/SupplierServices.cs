using BusinessManagement.Application.Interfaces;
using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.DTO.SupplierDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.Application.Services
{
    public class SupplierServices : ISupplierServices
    {
        private readonly ISupplierRepository _repository;
        public SupplierServices(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddSupplierDto> AddSupplierAsync(AddSupplierDto dto)
        {
            return await _repository.AddSupplierAsync(dto);
        }

        public Task DeleteSupplierAsync(int id)
        {
            return _repository.DeleteSupplierAsync(id);
        }

        public async Task<List<ResponseSupplierDto>> GetAllAsync()
        {
           return await _repository.GetAllAsync();
        }

        public async Task<UpdateSupplierDto> UpdateSupplierAsync(int id, UpdateSupplierDto dto)
        {
            return await _repository.UpdateSupplierAsync(id, dto);
        }
    }
}
