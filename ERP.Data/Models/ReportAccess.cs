using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Data.Models
{
    public partial class ReportAccess
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public int DepartmentId { get; set; }
        public int TeamId { get; set; }
        public int AccessLevelId { get; set; }
        public int UserId { get; set; }
        public bool IsShare { get; set; }
        public bool IsSubscribe { get; set; }
        public bool IsExportPdf { get; set; }
        public bool IsExportExcel { get; set; }
        public bool IsScreenShot { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Department Department { get; set; }
        public virtual Report Report { get; set; }
        public virtual UserGroup Team { get; set; }
        public virtual User User { get; set; }
    }
}
