using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.DTO.UserDTOs
{
    public class ResponseUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public int RolId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
