using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Domain.Entities
{
    public class Transfer
    {
        public int Id { get; set; }
        public int ProductionId { get; set; }
        public int TransferAmount { get; set; }
        public int BranchId { get; set; }
        public DateTime TransferDate { get; set; }
        public string Description { get; set; }
    }
}
