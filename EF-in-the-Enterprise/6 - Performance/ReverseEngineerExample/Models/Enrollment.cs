using System;
using System.Collections.Generic;

namespace ReverseEngineerExample.Models
{
    public partial class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int PersonID { get; set; }
        public Nullable<int> Grade { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public virtual Course Course { get; set; }
        public virtual Person Person { get; set; }
    }
}
