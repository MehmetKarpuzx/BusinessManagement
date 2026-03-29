using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.DTO.ProductDTOs
{
    public class UpdateProductDto
    {
       
        public string Name { get; set; }
        public string? PhotoUrl { get; set; }
        public int PersonelPrice { get; set; }
        public int CorporatePrice { get; set; }
        public int WholesalePrice { get; set; }
        public string? Description { get; set; }
    }
}
