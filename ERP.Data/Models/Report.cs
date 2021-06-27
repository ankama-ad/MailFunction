using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Data.Models
{
    public partial class Report
    {
        public Report()
        {
            ApprovalMasters = new HashSet<ApprovalMaster>();
            ReportAccesses = new HashSet<ReportAccess>();
            ReportFilters = new HashSet<ReportFilter>();
            ReportMoreInfos = new HashSet<ReportMoreInfo>();
            ReportRequests = new HashSet<ReportRequest>();
            ReportSubscriptions = new HashSet<ReportSubscription>();
            UserActions = new HashSet<UserAction>();
        }

        public int Id { get; set; }
        public string PbiReportId { get; set; }
        public string ReportName { get; set; }
        public string PbiReportAppId { get; set; }
        public string ReportPrefix { get; set; }
        public string PbiWorkspaceId { get; set; }
        public int DepartmentId { get; set; }
        public int? CategoryId { get; set; }
        public string ReportDescription { get; set; }
        public short? ReportType { get; set; }
        public string CognosLink { get; set; }
        public string Notes { get; set; }
        public bool HasDataLevelSecurity { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ReportCategory Category { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<ApprovalMaster> ApprovalMasters { get; set; }
        public virtual ICollection<ReportAccess> ReportAccesses { get; set; }
        public virtual ICollection<ReportFilter> ReportFilters { get; set; }
        public virtual ICollection<ReportMoreInfo> ReportMoreInfos { get; set; }
        public virtual ICollection<ReportRequest> ReportRequests { get; set; }
        public virtual ICollection<ReportSubscription> ReportSubscriptions { get; set; }
        public virtual ICollection<UserAction> UserActions { get; set; }
    }
}
