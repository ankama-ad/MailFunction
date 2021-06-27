using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Data.Models
{
    public partial class ApprovalMaster
    {
        public int ApprovalId { get; set; }
        public int ApprovalUserId { get; set; }
        public int? ReportId { get; set; }
        public short IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Report Report { get; set; }
    }
}
