using System;

namespace BusinessManagement.MVC.DTO.CustomerDTOs
{
    public class ResultCustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CustomerTypeId { get; set; }
        public string? Adress { get; set; }
        public string? City { get; set; }
        public string? Tckn { get; set; }
        public string? TaxNumber { get; set; }
        public string? TaxOffice { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
