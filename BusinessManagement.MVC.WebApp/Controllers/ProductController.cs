using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace BusinessManagement.MVC.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _productServices.GetAllProductsAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductDto addProductDto)
        {
            await _productServices.AddProductAsync(addProductDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productServices.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var values = await _productServices.GetAllProductsAsync();
            var value = values.FirstOrDefault(x => x.Id == id);
            if (value == null) return NotFound();

            var updateDto = new UpdateProductDto
            {
                Id = value.Id,
                Name = value.Name,
                PhotoUrl = value.PhotoUrl,
                PersonelPrice = value.PersonelPrice,
                CorporatePrice = value.CorporatePrice,
                WholesalePrice = value.WholesalePrice,
                Description = value.Description
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productServices.UpdateProductAsync(updateProductDto, updateProductDto.Id);
            return RedirectToAction("Index");
        }
    }
}
