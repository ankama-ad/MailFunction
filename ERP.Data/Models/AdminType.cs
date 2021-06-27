using System;
using System.Collections.Generic;

#nullable disable

namespace ERP.Data.Models
{
    public partial class AdminType
    {
        public int AdminTypeId { get; set; }
        public string TypeName { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
