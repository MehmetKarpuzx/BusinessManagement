using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.DTO.BranchDTOs
{
    public class ResponseBranchDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Code { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
