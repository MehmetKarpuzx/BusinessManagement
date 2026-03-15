using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.DTO.SupplierDTOs
{
    public class ResponseSupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Adress { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
