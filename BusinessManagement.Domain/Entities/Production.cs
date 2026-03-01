using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Domain.Entities
{
    public class Production
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public int UnitTypeId { get; set; }
        public int CostPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public int BranchId { get; set; }
        public int TotalPrice { get; set; }
        public string Description { get; set; }
    }
}
