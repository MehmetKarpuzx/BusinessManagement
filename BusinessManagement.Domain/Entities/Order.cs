using BusinessManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Domain.Entities
{
    public class Order
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
