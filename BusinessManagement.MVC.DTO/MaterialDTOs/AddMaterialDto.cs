namespace BusinessManagement.MVC.DTO.MaterialDTOs
{
    public class AddMaterialDto
    {
        public string Name { get; set; }
        public int UnitTypeId { get; set; }
        public int? MinStock { get; set; }
        public string? Description { get; set; }
    }
}
