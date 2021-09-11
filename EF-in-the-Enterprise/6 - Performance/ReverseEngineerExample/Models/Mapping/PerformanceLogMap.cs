using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ReverseEngineerExample.Models.Mapping
{
    public class PerformanceLogMap : EntityTypeConfiguration<PerformanceLog>
    {
        public PerformanceLogMap()
        {
            // Primary Key
            this.HasKey(t => t.PerformanceLogId);

            // Properties
            this.Property(t => t.Action)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Model)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Query)
                .IsRequired();

            this.Property(t => t.User)
                .HasMaxLength(50);

            this.Property(t => t.IPAddress)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("PerformanceLog");
            this.Property(t => t.PerformanceLogId).HasColumnName("PerformanceLogId");
            this.Property(t => t.Action).HasColumnName("Action");
            this.Property(t => t.Model).HasColumnName("Model");
            this.Property(t => t.Query).HasColumnName("Query");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.Execution).HasColumnName("Execution");
            this.Property(t => t.User).HasColumnName("User");
            this.Property(t => t.IPAddress).HasColumnName("IPAddress");
            this.Property(t => t.RequestUrl).HasColumnName("RequestUrl");
        }
    }
}
