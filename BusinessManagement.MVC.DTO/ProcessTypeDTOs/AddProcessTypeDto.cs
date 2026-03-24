using System;

namespace BusinessManagement.MVC.DTO.ProcessTypeDTOs
{
    public class AddProcessTypeDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
