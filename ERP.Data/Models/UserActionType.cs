using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Data.Models
{
    public partial class UserActionType
    {
        public UserActionType()
        {
            UserActions = new HashSet<UserAction>();
        }

        public int UserActionTypeId { get; set; }
        public string ActionType { get; set; }
        public string ActionTypeDesc { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<UserAction> UserActions { get; set; }
    }
}
