using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.ProductionDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace BusinessManagement.MVC.WebApp.Controllers
{
    public class ProductionController : Controller
    {
        private readonly IProductionServices _productionServices;
        private readonly ILoadDropdownServices _loadDropdownServices;

        public ProductionController(IProductionServices productionServices, ILoadDropdownServices loadDropdownServices)
        {
            _productionServices = productionServices;
            _loadDropdownServices = loadDropdownServices;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _productionServices.GetAllProductionsAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AddProduction()
        {
            ViewBag.Products = await _loadDropdownServices.GetProductsSelectListAsync();
            ViewBag.Units = await _loadDropdownServices.GetUnitsSelectListAsync();
            ViewBag.Branches = await _loadDropdownServices.GetBranchesSelectListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduction(AddProductionDto addProductionDto)
        {
            await _productionServices.AddProductionAsync(addProductionDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProduction(int id)
        {
            await _productionServices.DeleteProductionAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduction(int id)
        {
            var values = await _productionServices.GetAllProductionsAsync();
            var value = values.FirstOrDefault(x => x.Id == id);
            if (value == null) return NotFound();

            var updateDto = new UpdateProductionDto
            {
                Id = value.Id,
                ProductId = value.ProductId,
                Amount = value.Amount,
                UnitTypeId = value.UnitTypeId,
                CostPrice = value.CostPrice,
                CreateDate = value.CreateDate,
                BranchId = value.BranchId,
                TotalPrice = value.TotalPrice,
                Description = value.Description
            };

            ViewBag.Products = await _loadDropdownServices.GetProductsSelectListAsync();
            ViewBag.Units = await _loadDropdownServices.GetUnitsSelectListAsync();
            ViewBag.Branches = await _loadDropdownServices.GetBranchesSelectListAsync();
            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduction(UpdateProductionDto updateProductionDto)
        {
            await _productionServices.UpdateProductionAsync(updateProductionDto, updateProductionDto.Id);
            return RedirectToAction("Index");
        }
    }
}
