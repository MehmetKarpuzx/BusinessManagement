using System;

namespace BusinessManagement.MVC.DTO.MaterialProcurementDTOs
{
    public class UpdateMaterialProcurementDto
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public DateTime ProcurementDate { get; set; }
        public int? InvoiceNo { get; set; }
        public int MaterialId { get; set; }
        public int? Amount { get; set; }
        public int? UnitPrice { get; set; }
        public int? TotalPrice { get; set; }
        public int? PaidPrice { get; set; }
        public int? RemainderPrice { get; set; }
        public int? UnitTypeId { get; set; }
        public int? BranchId { get; set; }
        public string? Description { get; set; }
    }
}
