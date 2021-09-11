using System;
using System.Collections.Generic;

namespace ReverseEngineerExample.Models
{
    public partial class Course
    {
        public Course()
        {
            this.CourseInstructors = new List<CourseInstructor>();
            this.Enrollments = new List<Enrollment>();
        }

        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
