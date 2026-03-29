using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.DTO.TransferDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace BusinessManagement.MVC.WebApp.Controllers
{
    public class TransferController : Controller
    {
        private readonly ITransferServices _transferServices;

        public TransferController(ITransferServices transferServices)
        {
            _transferServices = transferServices;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _transferServices.GetAllTransfersAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddTransfer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTransfer(AddTransferDto addTransferDto)
        {
            await _transferServices.AddTransferAsync(addTransferDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteTransfer(int id)
        {
            await _transferServices.DeleteTransferAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTransfer(int id)
        {
            var values = await _transferServices.GetAllTransfersAsync();
            var value = values.FirstOrDefault(x => x.Id == id);
            if (value == null) return NotFound();

            var updateDto = new UpdateTransferDto
            {
                Id = value.Id,
                ProductionId = value.ProductionId,
                TransferAmount = value.TransferAmount,
                BranchId = value.BranchId,
                TransferDate = value.TransferDate,
                Description = value.Description
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTransfer(UpdateTransferDto updateTransferDto)
        {
            await _transferServices.UpdateTransferAsync(updateTransferDto, updateTransferDto.Id);
            return RedirectToAction("Index");
        }
    }
}
