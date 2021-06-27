using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Data.Models
{
    public partial class DepartmentAdmin
    {
        public int DepartmentAdminId { get; set; }
        public int DepartmentId { get; set; }
        public int UserId { get; set; }
        public int? LimitToGroupAdmin { get; set; }
        public int? LimitToUserGroup { get; set; }
        public bool IsEnableToCrtGroupAdmin { get; set; }
        public bool IsEnableToCrtUserGroups { get; set; }
        public bool IsEnableToCrtUsserRoles { get; set; }
        public bool IsEnableToAddNewReport { get; set; }
        public bool IsAbleToReportRequestAccess { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
