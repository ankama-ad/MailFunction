using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Data.Subscriptions
{
    public class SubscriptionDataModel
    {
        public int ReportSubscriptionId { get; set; }
        public string ReportId { get; set; }
        public string WorkspaceId { get; set; }

        public string Email { get; set; }
        public int? UseridEmail { get; set; }
        public string Frequency { get; set; }
        public string Weekday { get; set; }
        public string DateOfMonth { get; set; }
        public TimeSpan? SheduledTime { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
