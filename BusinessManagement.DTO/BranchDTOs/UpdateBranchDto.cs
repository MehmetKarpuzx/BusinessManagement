using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.DTO.BranchDTOs
{
    public class UpdateBranchDto
    {
       
        public string Name { get; set; }
        public int? Code { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

        public bool  IsDeleted { get; set; }
    }
}
