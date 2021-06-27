using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Data.Models
{
    public partial class UserGroup
    {
        public UserGroup()
        {
            GroupMembers = new HashSet<GroupMember>();
            ReportAccesses = new HashSet<ReportAccess>();
        }

        public int UserGroupId { get; set; }
        public string UserGroupName { get; set; }
        public int DeptId { get; set; }
        public int? ParentId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Department Dept { get; set; }
        public virtual ICollection<GroupMember> GroupMembers { get; set; }
        public virtual ICollection<ReportAccess> ReportAccesses { get; set; }
    }
}
