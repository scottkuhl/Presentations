using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ReverseEngineerExample.Models.Mapping
{
    public class CourseInstructorMap : EntityTypeConfiguration<CourseInstructor>
    {
        public CourseInstructorMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CourseID, t.PersonID });

            // Properties
            this.Property(t => t.CourseID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PersonID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CourseInstructor");
            this.Property(t => t.CourseID).HasColumnName("CourseID");
            this.Property(t => t.PersonID).HasColumnName("PersonID");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");

            // Relationships
            this.HasRequired(t => t.Course)
                .WithMany(t => t.CourseInstructors)
                .HasForeignKey(d => d.CourseID);
            this.HasRequired(t => t.Person)
                .WithMany(t => t.CourseInstructors)
                .HasForeignKey(d => d.PersonID);

        }
    }
}
