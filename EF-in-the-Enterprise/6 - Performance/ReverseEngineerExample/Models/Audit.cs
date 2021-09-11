using System;
using System.Collections.Generic;

namespace ReverseEngineerExample.Models
{
    public partial class Audit
    {
        public int AuditId { get; set; }
        public int TableId { get; set; }
        public string User { get; set; }
        public string TableName { get; set; }
        public string Action { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string Before { get; set; }
        public string After { get; set; }
    }
}
