using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.DTO.UnitDTOs
{
    public class UpdateUnitDto
    {
      
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
