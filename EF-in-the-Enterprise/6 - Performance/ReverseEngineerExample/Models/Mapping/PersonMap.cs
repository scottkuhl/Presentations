using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ReverseEngineerExample.Models.Mapping
{
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            // Primary Key
            this.HasKey(t => t.PersonID);

            // Properties
            this.Property(t => t.LastName)
                .HasMaxLength(50);

            this.Property(t => t.FirstName)
                .HasMaxLength(50);

            this.Property(t => t.Discriminator)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.UserName)
                .HasMaxLength(256);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Person");
            this.Property(t => t.PersonID).HasColumnName("PersonID");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.HireDate).HasColumnName("HireDate");
            this.Property(t => t.EnrollmentDate).HasColumnName("EnrollmentDate");
            this.Property(t => t.Discriminator).HasColumnName("Discriminator");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");
        }
    }
}
