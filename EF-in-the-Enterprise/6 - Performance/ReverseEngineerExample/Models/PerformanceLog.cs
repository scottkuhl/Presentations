using System;
using System.Collections.Generic;

namespace ReverseEngineerExample.Models
{
    public partial class PerformanceLog
    {
        public int PerformanceLogId { get; set; }
        public string Action { get; set; }
        public string Model { get; set; }
        public string Query { get; set; }
        public System.DateTime Date { get; set; }
        public long Execution { get; set; }
        public string User { get; set; }
        public string IPAddress { get; set; }
        public string RequestUrl { get; set; }
    }
}
