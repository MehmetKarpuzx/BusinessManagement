using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.WarehouseMovementDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace BusinessManagement.MVC.WebApp.Controllers
{
    public class WarehouseMovementController : Controller
    {
        private readonly IWarehouseMovementServices _warehouseMovementServices;
        private readonly ILoadDropdownServices _loadDropdownServices;

        public WarehouseMovementController(IWarehouseMovementServices warehouseMovementServices, ILoadDropdownServices loadDropdownServices)
        {
            _warehouseMovementServices = warehouseMovementServices;
            _loadDropdownServices = loadDropdownServices;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _warehouseMovementServices.GetAllWarehouseMovementsAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AddWarehouseMovement()
        {
            ViewBag.ProcessTypes = await _loadDropdownServices.GetProcessTypesSelectListAsync();
            ViewBag.Suppliers = await _loadDropdownServices.GetSuppliersSelectListAsync();
            ViewBag.Materials = await _loadDropdownServices.GetMaterialsSelectListAsync();
            ViewBag.Branches = await _loadDropdownServices.GetBranchesSelectListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddWarehouseMovement(AddWarehouseMovementDto addWarehouseMovementDto)
        {
            await _warehouseMovementServices.AddWarehouseMovementAsync(addWarehouseMovementDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteWarehouseMovement(int id)
        {
            await _warehouseMovementServices.DeleteWarehouseMovementAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateWarehouseMovement(int id)
        {
            var values = await _warehouseMovementServices.GetAllWarehouseMovementsAsync();
            var value = values.FirstOrDefault(x => x.Id == id);
            if (value == null) return NotFound();

            var updateDto = new UpdateWarehouseMovementDto
            {
                Id = value.Id,
                ProcessTypeId = value.ProcessTypeId,
                SupplierId = value.SupplierId,
                MaterialId = value.MaterialId,
                UnitPrice = value.UnitPrice,
                Amount = value.Amount,
                TotalPrice = value.TotalPrice,
                InvoiceNo = value.InvoiceNo,
                BranchId = value.BranchId,
                TransactionDate = value.TransactionDate,
                Description = value.Description
            };

            ViewBag.ProcessTypes = await _loadDropdownServices.GetProcessTypesSelectListAsync();
            ViewBag.Suppliers = await _loadDropdownServices.GetSuppliersSelectListAsync();
            ViewBag.Materials = await _loadDropdownServices.GetMaterialsSelectListAsync();
            ViewBag.Branches = await _loadDropdownServices.GetBranchesSelectListAsync();
            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWarehouseMovement(UpdateWarehouseMovementDto updateWarehouseMovementDto)
        {
            await _warehouseMovementServices.UpdateWarehouseMovementAsync(updateWarehouseMovementDto: updateWarehouseMovementDto, id: updateWarehouseMovementDto.Id);
            return RedirectToAction("Index");
        }
    }
}
