using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Data.Models
{
    public partial class GroupMember
    {
        public int GroupMemberId { get; set; }
        public int UserId { get; set; }
        public int? UserGroupId { get; set; }
        public short IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual User User { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
}
