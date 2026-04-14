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
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;

        public ProductController(IProductServices productServices, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _productServices = productServices;
            _configuration = configuration;
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
        public async Task<IActionResult> AddProduct(AddProductDto addProductDto, Microsoft.AspNetCore.Http.IFormFile? PhotoFile)
        {
            if (PhotoFile != null && PhotoFile.Length > 0)
            {
                var folderPath = _configuration["FilePaths:ProductPhotos"];
                if (string.IsNullOrEmpty(folderPath))
                {
                    folderPath = @"C:\Uploads\ProductPhotos"; // Fallback
                }
                
                if (!System.IO.Directory.Exists(folderPath))
                {
                    System.IO.Directory.CreateDirectory(folderPath);
                }

                var extension = System.IO.Path.GetExtension(PhotoFile.FileName);
                var safeProductName = string.Join("_", addProductDto.Name.Split(System.IO.Path.GetInvalidFileNameChars()));
                var fileName = safeProductName + extension;
                
                var filePath = System.IO.Path.Combine(folderPath, fileName);

                using (var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
                {
                    await PhotoFile.CopyToAsync(stream);
                }

                addProductDto.PhotoUrl = $"/Uploads/ProductPhotos/{fileName}";
            }
            
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
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto, Microsoft.AspNetCore.Http.IFormFile? PhotoFile, bool RemovePhoto = false)
        {
            var folderPath = _configuration["FilePaths:ProductPhotos"];
            if (string.IsNullOrEmpty(folderPath))
            {
                folderPath = @"C:\Uploads\ProductPhotos";
            }

            if (PhotoFile != null && PhotoFile.Length > 0)
            {
                if (!System.IO.Directory.Exists(folderPath))
                {
                    System.IO.Directory.CreateDirectory(folderPath);
                }

                // Eski dosyayı sil (eğer varsa)
                if (!string.IsNullOrEmpty(updateProductDto.PhotoUrl))
                {
                    var oldFileName = System.IO.Path.GetFileName(updateProductDto.PhotoUrl);
                    var oldFilePath = System.IO.Path.Combine(folderPath, oldFileName);
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                var extension = System.IO.Path.GetExtension(PhotoFile.FileName);
                var safeProductName = string.Join("_", updateProductDto.Name.Split(System.IO.Path.GetInvalidFileNameChars()));
                var fileName = safeProductName + extension;
                var filePath = System.IO.Path.Combine(folderPath, fileName);

                using (var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
                {
                    await PhotoFile.CopyToAsync(stream);
                }

                updateProductDto.PhotoUrl = $"/Uploads/ProductPhotos/{fileName}";
            }
            else if (RemovePhoto)
            {
                // Kullanıcı "Fotoğrafı Kaldır" dedi ve yeni dosya seçmedi
                if (!string.IsNullOrEmpty(updateProductDto.PhotoUrl))
                {
                    var oldFileName = System.IO.Path.GetFileName(updateProductDto.PhotoUrl);
                    var oldFilePath = System.IO.Path.Combine(folderPath, oldFileName);
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }
                updateProductDto.PhotoUrl = null;
            }

            await _productServices.UpdateProductAsync(updateProductDto, updateProductDto.Id);
            return RedirectToAction("Index");
        }
    }
}
