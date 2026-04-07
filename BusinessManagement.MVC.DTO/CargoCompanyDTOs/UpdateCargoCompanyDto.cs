namespace BusinessManagement.MVC.DTO.CargoCompanyDTOs
{
    public class UpdateCargoCompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
