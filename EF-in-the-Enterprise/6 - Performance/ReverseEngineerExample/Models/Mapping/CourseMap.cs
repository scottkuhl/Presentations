using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ReverseEngineerExample.Models.Mapping
{
    public class CourseMap : EntityTypeConfiguration<Course>
    {
        public CourseMap()
        {
            // Primary Key
            this.HasKey(t => t.CourseID);

            // Properties
            this.Property(t => t.CourseID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Title)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Course");
            this.Property(t => t.CourseID).HasColumnName("CourseID");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Credits).HasColumnName("Credits");
            this.Property(t => t.DepartmentID).HasColumnName("DepartmentID");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");

            // Relationships
            this.HasRequired(t => t.Department)
                .WithMany(t => t.Courses)
                .HasForeignKey(d => d.DepartmentID);

        }
    }
}
