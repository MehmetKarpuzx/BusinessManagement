using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.DTO.CustomerDTOs
{
    public class UpdateCustomerDto
    {
       
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CustomerTypeId { get; set; }
        public string? Adress { get; set; }
        public bool IsDeleted { get; set; }

    }
}
