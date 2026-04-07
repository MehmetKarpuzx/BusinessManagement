using System;
using BusinessManagement.MVC.Domain.Enums;

namespace BusinessManagement.MVC.DTO.OrderDTOs
{
    public class ResultOrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BranchId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int? CargoCompanyId { get; set; }
        public int? CargoPrice { get; set; }
        public string? CargoDescription { get; set; }
        public int? DiscountPrice { get; set; }
        public string? DiscountDescription { get; set; }
        public int PaymentReceived { get; set; }
        public int? RemainderPrice { get; set; }
        public string? Description { get; set; }
    }
}
