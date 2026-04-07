using System;

namespace BusinessManagement.MVC.DTO.UserDTOs
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string? Password { get; set; }
        public int RolId { get; set; }
        public bool IsActive { get; set; }
    }
}
