using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Data.Models
{
    public partial class ReportMoreInfo
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Report Report { get; set; }
    }
}
