using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ReverseEngineerExample.Models.Mapping
{
    public class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            // Primary Key
            this.HasKey(t => t.DepartmentID);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.RowVersion)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Department");
            this.Property(t => t.DepartmentID).HasColumnName("DepartmentID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Budget).HasColumnName("Budget");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.PersonID).HasColumnName("PersonID");
            this.Property(t => t.RowVersion).HasColumnName("RowVersion");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");

            // Relationships
            this.HasOptional(t => t.Person)
                .WithMany(t => t.Departments)
                .HasForeignKey(d => d.PersonID);

        }
    }
}
