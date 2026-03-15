using BusinessManagement.DTO.SupplierDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Interfaces
{
    public interface ISupplierServices
    {
        Task<List<ResponseSupplierDto>> GetAllAsync();
        Task<AddSupplierDto> AddSupplierAsync(AddSupplierDto supplierDto);
        Task<UpdateSupplierDto> UpdateSupplierAsync(int id, UpdateSupplierDto supplierDto);
        Task DeleteSupplierAsync(int id);
    }
}
