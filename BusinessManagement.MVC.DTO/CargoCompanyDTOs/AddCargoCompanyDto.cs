using System;

namespace BusinessManagement.MVC.DTO.CargoCompanyDTOs
{
    public class AddCargoCompanyDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
