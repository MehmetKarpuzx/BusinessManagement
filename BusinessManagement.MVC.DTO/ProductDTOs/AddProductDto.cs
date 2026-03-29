namespace BusinessManagement.MVC.DTO.ProductDTOs
{
    public class AddProductDto
    {
        public string Name { get; set; }
        public string? PhotoUrl { get; set; }
        public int PersonelPrice { get; set; }
        public int CorporatePrice { get; set; }
        public int WholesalePrice { get; set; }
        public string? Description { get; set; }
    }
}
