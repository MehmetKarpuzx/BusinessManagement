using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.DTO.MaterialDTOs
{
    public class UpdateMaterialDto
    {
        
        public string Name { get; set; }
        public int UnitTypeId { get; set; }
        public int? MinStock { get; set; }
        public string? Description { get; set; }
    }
}
