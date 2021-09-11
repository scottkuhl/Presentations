using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ReverseEngineerExample.Models.Mapping
{
    public class OfficeAssignmentMap : EntityTypeConfiguration<OfficeAssignment>
    {
        public OfficeAssignmentMap()
        {
            // Primary Key
            this.HasKey(t => t.PersonID);

            // Properties
            this.Property(t => t.PersonID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Location)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("OfficeAssignment");
            this.Property(t => t.PersonID).HasColumnName("PersonID");
            this.Property(t => t.Location).HasColumnName("Location");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");

            // Relationships
            this.HasRequired(t => t.Person)
                .WithOptional(t => t.OfficeAssignment);

        }
    }
}
