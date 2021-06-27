using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Data.Models
{
    public partial class ReportCategory
    {
        public ReportCategory()
        {
            Reports = new HashSet<Report>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? DepartmentId { get; set; }
        public string Description { get; set; }
        public short IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
