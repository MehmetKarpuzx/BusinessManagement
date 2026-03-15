using BusinessManagement.Application.Interfaces;
using BusinessManagement.DTO.CargoCompanyDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessManagement.RestFullApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CargoCompanyController : Controller
    {
        private readonly ICargoCompanyServices _cargoCompanyServices;
        public CargoCompanyController(ICargoCompanyServices cargoCompanyServices)
        {
            _cargoCompanyServices = cargoCompanyServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _cargoCompanyServices.GetAllCargoCompaniesAsync();
            return Ok(entities);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCargoCompanyDto dto)
        {
            var addedEntity = await _cargoCompanyServices.AddCargoCompanyAsync(dto);
            return Ok(addedEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateCargoCompanyDto dto, int id)
        {
            var updatedEntity = await _cargoCompanyServices.UpdateCargoCompanyAsync(id, dto);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cargoCompanyServices.DeleteCargoCompanyAsync(id);
            return NoContent();
        }
    }
}
