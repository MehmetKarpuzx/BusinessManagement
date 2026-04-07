using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.DTO.CargoCompanyDTOs
{
    public class UpdateCargoCompanyDto
    {
        
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted   { get; set; }

    }
}
