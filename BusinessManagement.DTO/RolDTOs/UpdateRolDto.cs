using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.DTO.RolDTOs
{
    public class UpdateRolDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
