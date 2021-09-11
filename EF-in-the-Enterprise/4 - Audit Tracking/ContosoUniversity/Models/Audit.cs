using System;

namespace ContosoUniversity.Models
{
   public class Audit
   {
       public int AuditId { get; set; }
       public int TableId { get; set; }
       public string User { get; set; }
       public string TableName { get; set; }
       public string Action { get; set; }
       public DateTime CreatedOn { get; set; }
       public string Before { get; set; }
       public string After { get; set; }
   }
}