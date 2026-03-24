using System;

namespace BusinessManagement.MVC.DTO.CargoCompanyDTOs
{
    public class ResultCargoCompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
