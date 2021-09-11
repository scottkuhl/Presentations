using System;

namespace ContosoUniversity.Models
{
    public abstract class AuditBase
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }        
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}