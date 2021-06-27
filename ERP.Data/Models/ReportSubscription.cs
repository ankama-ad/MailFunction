using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Data.Models
{
    public partial class ReportSubscription
    {
        public ReportSubscription()
        {
            ReportSubscriptionLogs = new HashSet<ReportSubscriptionLog>();
        }

        public int ReportSubscriptionId { get; set; }
        public int? ReportId { get; set; }
        public int? UseridEmail { get; set; }
        public string Frequency { get; set; }
        public string Weekday { get; set; }
        public string DateOfMonth { get; set; }
        public TimeSpan? SheduledTime { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Report Report { get; set; }
        public virtual User UseridEmailNavigation { get; set; }
        public virtual ICollection<ReportSubscriptionLog> ReportSubscriptionLogs { get; set; }
    }
}
