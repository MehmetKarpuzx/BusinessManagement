using System;

namespace BusinessManagement.MVC.DTO.PaymentDTOs
{
    public class UpdatePaymentDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PaymentAmount { get; set; }
        public int Amount { get; set; }
        public int OrderId { get; set; }
        public int PaymentMethodId { get; set; }
        public string? Description { get; set; }
        public DateTime PaymentDate { get; set; }
        public int? DiscountAmount { get; set; }
        public string? DiscountDescription { get; set; }
    }
}
