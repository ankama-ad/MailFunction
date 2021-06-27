using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Data.Models
{
    public partial class ReportSubscriptionLog
    {
        public int Id { get; set; }
        public int? ReportSubscriptionId { get; set; }
        public DateTime GeneratedTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ReportSubscription ReportSubscription { get; set; }
    }
}
