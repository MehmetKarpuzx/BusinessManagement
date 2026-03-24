namespace BusinessManagement.MVC.DTO.CustomerTypeDTOs
{
    public class UpdateCustomerTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
