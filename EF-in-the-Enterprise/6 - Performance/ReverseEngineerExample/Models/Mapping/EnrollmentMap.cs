using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ReverseEngineerExample.Models.Mapping
{
    public class EnrollmentMap : EntityTypeConfiguration<Enrollment>
    {
        public EnrollmentMap()
        {
            // Primary Key
            this.HasKey(t => t.EnrollmentID);

            // Properties
            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Enrollment");
            this.Property(t => t.EnrollmentID).HasColumnName("EnrollmentID");
            this.Property(t => t.CourseID).HasColumnName("CourseID");
            this.Property(t => t.PersonID).HasColumnName("PersonID");
            this.Property(t => t.Grade).HasColumnName("Grade");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");

            // Relationships
            this.HasRequired(t => t.Course)
                .WithMany(t => t.Enrollments)
                .HasForeignKey(d => d.CourseID);
            this.HasRequired(t => t.Person)
                .WithMany(t => t.Enrollments)
                .HasForeignKey(d => d.PersonID);

        }
    }
}
