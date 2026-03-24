using System;

namespace BusinessManagement.MVC.DTO.SupplierDTOs
{
    public class UpdateSupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Adress { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
