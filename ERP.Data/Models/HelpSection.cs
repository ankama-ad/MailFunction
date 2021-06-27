using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Data.Models
{
    public partial class HelpSection
    {
        public HelpSection()
        {
            HelpIndices = new HashSet<HelpIndex>();
        }

        public int HelpSectionId { get; set; }
        public string HelpSectionName { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<HelpIndex> HelpIndices { get; set; }
    }
}
