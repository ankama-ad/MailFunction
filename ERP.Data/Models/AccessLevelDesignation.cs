using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Data.Models
{
    public partial class AccessLevelDesignation
    {
        public int Id { get; set; }
        public int AccessLevelId { get; set; }
        public int? DepartmentId { get; set; }
        public int? DesignationId { get; set; }
        public short IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual AccessLevel AccessLevel { get; set; }
        public virtual Department Department { get; set; }
    }
}
