using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.DTO.CustomerDTOs
{
    public class AddCustomerDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CustomerTypeId { get; set; }
        public string? Adress { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
