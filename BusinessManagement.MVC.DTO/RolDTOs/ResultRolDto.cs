using System;

namespace BusinessManagement.MVC.DTO.RolDTOs
{
    public class ResultRolDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
