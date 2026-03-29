using BusinessManagement.MVC.DTO.SupplierDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.MVC.Application.Interfaces
{
    public interface ISupplierServices
    {
        Task<List<ResultSupplierDto>> GetAllSuppliersAsync();
        Task<AddSupplierDto> AddSupplierAsync(AddSupplierDto addSupplierDto);
        Task<UpdateSupplierDto> UpdateSupplierAsync(UpdateSupplierDto updateSupplierDto, int id);
        Task DeleteSupplierAsync(int id);
    }
}
