using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Data.Models
{
    public partial class ReportRequest
    {
        public int ReportRequestId { get; set; }
        public int ReportId { get; set; }
        public int? RequestedBy { get; set; }
        public int? ApprovedBy { get; set; }
        public string Comments { get; set; }
        public short IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Report Report { get; set; }
    }
}
