using System;

namespace BusinessManagement.MVC.DTO.CustomerTypeDTOs
{
    public class ResultCustomerTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
