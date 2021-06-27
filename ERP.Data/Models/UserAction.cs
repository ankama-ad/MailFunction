using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Data.Models
{
    public partial class UserAction
    {
        public int Id { get; set; }
        public int? ReportId { get; set; }
        public string PageName { get; set; }
        public int? UserActionTypeId { get; set; }
        public string ActionDesc { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string Timestamp { get; set; }
        public string UserBrowserDetails { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Report Report { get; set; }
        public virtual UserActionType UserActionType { get; set; }
    }
}
