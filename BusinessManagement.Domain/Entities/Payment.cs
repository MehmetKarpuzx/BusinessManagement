using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int? DiscountAmount { get; set; }
        public string? DiscountDescription { get; set; }
    }
}
