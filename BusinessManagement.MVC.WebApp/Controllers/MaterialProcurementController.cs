using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.MaterialProcurementDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace BusinessManagement.MVC.WebApp.Controllers
{
    public class MaterialProcurementController : Controller
    {
        private readonly IMaterialProcurementServices _materialProcurementServices;

        public MaterialProcurementController(IMaterialProcurementServices materialProcurementServices)
        {
            _materialProcurementServices = materialProcurementServices;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _materialProcurementServices.GetAllMaterialProcurementsAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddMaterialProcurement()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMaterialProcurement(AddMaterialProcurementDto addMaterialProcurementDto)
        {
            await _materialProcurementServices.AddMaterialProcurementAsync(addMaterialProcurementDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteMaterialProcurement(int id)
        {
            await _materialProcurementServices.DeleteMaterialProcurementAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMaterialProcurement(int id)
        {
            var values = await _materialProcurementServices.GetAllMaterialProcurementsAsync();
            var value = values.FirstOrDefault(x => x.Id == id);
            if (value == null) return NotFound();

            var updateDto = new UpdateMaterialProcurementDto
            {
                Id = value.Id,
                MaterialId = value.MaterialId,
                SupplierId = value.SupplierId,
                Amount = value.Amount,
                UnitTypeId = value.UnitTypeId,
                UnitPrice = value.UnitPrice,
                TotalPrice = value.TotalPrice,
                InvoiceNo = value.InvoiceNo,
                BranchId = value.BranchId,
                ProcurementDate = value.ProcurementDate,
                Description = value.Description
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMaterialProcurement(UpdateMaterialProcurementDto updateMaterialProcurementDto)
        {
            await _materialProcurementServices.UpdateMaterialProcurementAsync(updateMaterialProcurementDto, updateMaterialProcurementDto.Id);
            return RedirectToAction("Index");
        }
    }
}
