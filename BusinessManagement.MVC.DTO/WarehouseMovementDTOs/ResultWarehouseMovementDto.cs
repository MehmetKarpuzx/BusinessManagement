using System;

namespace BusinessManagement.MVC.DTO.WarehouseMovementDTOs
{
    public class ResultWarehouseMovementDto
    {
        public int Id { get; set; }
        public int ProcessTypeId { get; set; }
        public int SupplierId { get; set; }
        public int MaterialId { get; set; }
        public int UnitPrice { get; set; }
        public int Amount { get; set; }
        public int TotalPrice { get; set; }
        public int? InvoiceNo { get; set; }
        public int BranchId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Description { get; set; }
    }
}
