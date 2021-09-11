using ContosoUniversity.Models;
using System;
using System.Diagnostics;
using System.Threading;
using System.Web;

namespace ContosoUniversity.DAL
{
    public class Timer : IDisposable
    {
        // Can replace EF with NLog or other logging framework.
        private SchoolContext _context;

        // Uses high precision stop watch.
        readonly Stopwatch _stopWatch = new Stopwatch();

        private string _action;
        private string _model;
        private string _query;

        // Constructor start timer, wrap in using pattern.
        public Timer(SchoolContext context, string action, string model, string query)
        {
            _context = context;
            _action = action;
            _model = model;
            _query = query;

            _stopWatch.Reset();
            _stopWatch.Start();
        }

        // Dispose stops timer and writes to log.
        public void Dispose()
        {
            _stopWatch.Stop();

            var perfLog = new PerformanceLog()
            {
                Action = _action,
                Model = _model,
                Query = _query,
                Date = DateTime.Now,
                Execution = _stopWatch.ElapsedMilliseconds,
                User = HttpContext.Current != null ? HttpContext.Current.User.Identity.Name : Thread.CurrentPrincipal.Identity.Name,
                IPAddress = HttpContext.Current != null ? HttpContext.Current.Request["REMOTE_ADDR"] : null,
                RequestUrl = HttpContext.Current != null ? HttpContext.Current.Request.Url.ToString() : null
            };
            _context.PerformanceLog.Add(perfLog);

            // No audit tracking needed.
            _context.SaveSimpleChange();
        }
    }
}