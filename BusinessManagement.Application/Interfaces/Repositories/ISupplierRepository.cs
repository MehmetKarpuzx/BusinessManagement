using BusinessManagement.DTO.SupplierDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Interfaces.Repositories
{
    public interface ISupplierRepository
    {
        Task<List<ResponseSupplierDto>> GetAllAsync();
        Task<AddSupplierDto> AddSupplierAsync(AddSupplierDto supplierDto);
        Task<UpdateSupplierDto> UpdateSupplierAsync(int id, UpdateSupplierDto supplierDto);
        Task DeleteSupplierAsync(int id);
    }
}
