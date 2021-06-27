using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Data.Models
{
    public partial class HelpIndex
    {
        public int HelpIndexId { get; set; }
        public int HelpSectionId { get; set; }
        public string Title { get; set; }
        public string HelpContent { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual HelpSection HelpSection { get; set; }
    }
}
