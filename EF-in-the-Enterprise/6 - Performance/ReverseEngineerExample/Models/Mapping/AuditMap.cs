using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ReverseEngineerExample.Models.Mapping
{
    public class AuditMap : EntityTypeConfiguration<Audit>
    {
        public AuditMap()
        {
            // Primary Key
            this.HasKey(t => t.AuditId);

            // Properties
            this.Property(t => t.User)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.TableName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Action)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.After)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Audit");
            this.Property(t => t.AuditId).HasColumnName("AuditId");
            this.Property(t => t.TableId).HasColumnName("TableId");
            this.Property(t => t.User).HasColumnName("User");
            this.Property(t => t.TableName).HasColumnName("TableName");
            this.Property(t => t.Action).HasColumnName("Action");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.Before).HasColumnName("Before");
            this.Property(t => t.After).HasColumnName("After");
        }
    }
}
