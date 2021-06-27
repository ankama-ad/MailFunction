using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Data.Models
{
    public partial class ReportFilter
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public string FilterKey { get; set; }
        public string FilterValue { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Report Report { get; set; }
    }
}
