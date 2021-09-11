using System;
using System.Collections.Generic;

namespace ReverseEngineerExample.Models
{
    public partial class OfficeAssignment
    {
        public int PersonID { get; set; }
        public string Location { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public virtual Person Person { get; set; }
    }
}
