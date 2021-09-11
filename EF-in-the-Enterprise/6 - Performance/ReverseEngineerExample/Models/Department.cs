using System;
using System.Collections.Generic;

namespace ReverseEngineerExample.Models
{
    public partial class Department
    {
        public Department()
        {
            this.Courses = new List<Course>();
        }

        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<int> PersonID { get; set; }
        public byte[] RowVersion { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual Person Person { get; set; }
    }
}
