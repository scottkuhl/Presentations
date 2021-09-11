using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ReverseEngineerExample.Models.Mapping;

namespace ReverseEngineerExample.Models
{
    public partial class EFEnterpriseContext : DbContext
    {
        static EFEnterpriseContext()
        {
            Database.SetInitializer<EFEnterpriseContext>(null);
        }

        public EFEnterpriseContext()
            : base("Name=EFEnterpriseContext")
        {
        }

        public DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseInstructor> CourseInstructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<PerformanceLog> PerformanceLogs { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new C__RefactorLogMap());
            modelBuilder.Configurations.Add(new AuditMap());
            modelBuilder.Configurations.Add(new CourseMap());
            modelBuilder.Configurations.Add(new CourseInstructorMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new EnrollmentMap());
            modelBuilder.Configurations.Add(new OfficeAssignmentMap());
            modelBuilder.Configurations.Add(new PerformanceLogMap());
            modelBuilder.Configurations.Add(new PersonMap());
        }
    }
}
