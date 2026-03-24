using System;

namespace BusinessManagement.MVC.DTO.CustomerTypeDTOs
{
    public class AddCustomerTypeDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
