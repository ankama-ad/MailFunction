using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Data.Models
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public int? DepartmentId { get; set; }
        public string Topic { get; set; }
        public string Feedback1 { get; set; }
        public short Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Department Department { get; set; }
    }
}
