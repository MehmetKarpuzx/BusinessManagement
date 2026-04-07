using System;

namespace BusinessManagement.MVC.DTO.TransferDTOs
{
    public class AddTransferDto
    {
        public int ProductionId { get; set; }
        public int TransferAmount { get; set; }
        public int BranchId { get; set; }
        public DateTime TransferDate { get; set; }
        public string Description { get; set; }
    }
}
