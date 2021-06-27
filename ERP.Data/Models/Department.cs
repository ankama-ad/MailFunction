using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Data.Models
{
    public partial class Department
    {
        public Department()
        {
            AccessLevelDesignations = new HashSet<AccessLevelDesignation>();
            Feedbacks = new HashSet<Feedback>();
            ReportAccesses = new HashSet<ReportAccess>();
            ReportCategories = new HashSet<ReportCategory>();
            Reports = new HashSet<Report>();
            UserGroups = new HashSet<UserGroup>();
            Users = new HashSet<User>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<AccessLevelDesignation> AccessLevelDesignations { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<ReportAccess> ReportAccesses { get; set; }
        public virtual ICollection<ReportCategory> ReportCategories { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
