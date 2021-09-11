using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Xml;

namespace ContosoUniversity.DAL
{
   public class SchoolContext : DbContext
   {
       public DbSet<Course> Courses { get; set; }
       public DbSet<Department> Departments { get; set; }
       public DbSet<Enrollment> Enrollments { get; set; }
       public DbSet<Instructor> Instructors { get; set; }
       public DbSet<Student> Students { get; set; }
       public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
       public DbSet<Person> People { get; set; }
       public DbSet<Audit> Audits { get; set; }
       public DbSet<PerformanceLog> PerformanceLog { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Instructors).WithMany(i => i.Courses)
                .Map(t => t.MapLeftKey("CourseID")
                    .MapRightKey("PersonID")
                    .ToTable("CourseInstructor"));
        }

        public override int SaveChanges()
        {
            var currentTime = DateTime.Now;
            var user = HttpContext.Current != null ? HttpContext.Current.User : Thread.CurrentPrincipal;
            var changes = new List<Change>();
            var perfEntities = string.Empty;

            // Loop through all changes.
            foreach (var entity in ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Deleted || e.State == EntityState.Modified))
            {
                try
                {
                    // Populate basic audit tracking columns.
                    dynamic dv = entity.Entity;
                    if (entity.State == EntityState.Added)
                    {
                        dv.CreatedBy = user.Identity.Name;
                        dv.CreatedOn = currentTime;
                    }
                    if (entity.State == EntityState.Modified)
                    {
                        dv.CreatedBy = entity.OriginalValues["CreatedBy"].ToString();
                        dv.CreatedOn = DateTime.Parse(entity.OriginalValues["CreatedOn"].ToString());
                        dv.UpdatedBy = user.Identity.Name;
                        dv.UpdatedOn = currentTime;
                    }
                }
                catch { }

                // Grab data for audit history tracking.
                var change = new Change();
                change.State = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entity.Entity);
                change.TableId = entity.State != EntityState.Added ? (int)change.State.EntityKey.EntityKeyValues[0].Value : 0;
                change.TableName = change.State.Entity.GetType().BaseType.Name == "Object" || change.State.Entity.GetType().BaseType.Name == "AuditBase" || change.State.Entity.GetType().BaseType.Name == "Person" ? change.State.Entity.GetType().Name : change.State.Entity.GetType().BaseType.Name;
                change.Action = entity.State.ToString();
                change.CurrentValues = entity.State != EntityState.Deleted ? entity.CurrentValues.Clone() : null;
                change.OriginalValues = entity.State != EntityState.Added ? entity.OriginalValues.Clone() : null;
                changes.Add(change);

                // Track a list of tables and actions for performance.
                perfEntities += change.TableName + "[" + change.Action + "],";
            }

            int result = 0;

            // Track time to save.
            using (var timer = new Timer(this, "SaveChanges", "Multiple", perfEntities))
            {
                result = base.SaveChanges();
            }

            // Record audit tracking.
            foreach (var change in changes)
            {
                // Get ID for newly added row.
                if (change.Action == "Added")
                    change.TableId = (int)change.State.EntityKey.EntityKeyValues[0].Value;

                var originalValues = new StringBuilder();
                var currentValues = new StringBuilder();

                // Turn original values into XML.
                var writer = XmlWriter.Create(originalValues);
                writer.WriteStartElement("values");
                if (change.OriginalValues != null)
                    foreach (var columnName in change.OriginalValues.PropertyNames)
                        writer.WriteElementString(columnName, change.OriginalValues[columnName] == null ? "" : change.OriginalValues[columnName].ToString());
                writer.WriteEndElement();
                writer.Flush();

                // Turn current values into XML.
                writer = XmlWriter.Create(currentValues);
                writer.WriteStartElement("values");
                if (change.CurrentValues != null)
                    foreach (var columnName in change.CurrentValues.PropertyNames)
                        writer.WriteElementString(columnName, change.CurrentValues[columnName] == null ? "" : change.CurrentValues[columnName].ToString());
                writer.WriteEndElement();
                writer.Flush();

                // Add the audit record.
                var audit = new Audit()
                {
                    TableId = change.TableId,
                    User = user.Identity.Name,
                    TableName = change.TableName,
                    Action = change.Action,
                    CreatedOn = currentTime,
                    Before = originalValues.ToString(),
                    After = currentValues.ToString()
                };
                Audits.Add(audit);
            }

            // Commit the audit records to the database.
            base.SaveChanges();

            return result;
        }
        
        // Save method that does not need any audit tracking.
        public int SaveSimpleChange()
        {
            return base.SaveChanges();
        }

       private class Change
       {
           public int TableId { get; set; }
           public string TableName { get; set; }
           public string Action { get; set; }
           public DbPropertyValues CurrentValues { get; set; }
           public DbPropertyValues OriginalValues { get; set; }
           public ObjectStateEntry State { get; set; }
       }
   }
}
