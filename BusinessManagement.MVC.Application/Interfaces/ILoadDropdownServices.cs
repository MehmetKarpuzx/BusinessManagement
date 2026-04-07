using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessManagement.MVC.Application.Interfaces
{
    public interface ILoadDropdownServices
    {
        Task<List<SelectListItem>> GetBranchesSelectListAsync();
        Task<List<SelectListItem>> GetCargoCompaniesSelectListAsync();
        Task<List<SelectListItem>> GetCustomersSelectListAsync();
        Task<List<SelectListItem>> GetCustomerTypesSelectListAsync();
       
        Task<List<SelectListItem>> GetMaterialsSelectListAsync();
        Task<List<SelectListItem>> GetOrdersSelectListAsync();
        Task<List<SelectListItem>> GetPaymentMethodsSelectListAsync();
        Task<List<SelectListItem>> GetPaymentsSelectListAsync();
        Task<List<SelectListItem>> GetProcessTypesSelectListAsync();
        Task<List<SelectListItem>> GetProductionsSelectListAsync();
        Task<List<SelectListItem>> GetProductsSelectListAsync();
        Task<List<SelectListItem>> GetSuppliersSelectListAsync();
        Task<List<SelectListItem>> GetTransfersSelectListAsync();
        Task<List<SelectListItem>> GetUnitsSelectListAsync();
        Task<List<SelectListItem>> GetWarehouseMovementsSelectListAsync();
        Task<List<SelectListItem>> GetMaterialProcurementsSelectListAsync();
        Task<List<SelectListItem>> GetRolesSelectListAsync();
    }
}
