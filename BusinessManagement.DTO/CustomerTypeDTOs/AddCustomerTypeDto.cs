using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.DTO.CustomerTypeDTOs
{
    public class AddCustomerTypeDto
    {
      
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
