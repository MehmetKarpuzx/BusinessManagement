using System;

namespace BusinessManagement.MVC.DTO.SupplierDTOs
{
    public class AddSupplierDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Adress { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
