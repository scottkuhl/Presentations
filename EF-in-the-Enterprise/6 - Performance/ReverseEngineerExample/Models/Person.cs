using System;
using System.Collections.Generic;

namespace ReverseEngineerExample.Models
{
    public partial class Person
    {
        public Person()
        {
            this.CourseInstructors = new List<CourseInstructor>();
            this.Departments = new List<Department>();
            this.Enrollments = new List<Enrollment>();
        }

        public int PersonID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public Nullable<System.DateTime> EnrollmentDate { get; set; }
        public string Discriminator { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual OfficeAssignment OfficeAssignment { get; set; }
    }
}
