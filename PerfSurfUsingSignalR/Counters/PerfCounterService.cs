using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PerfSurfUsingSignalR.Counters
{
    public class PerfCounterService
    {
        private List<PerfCounterWrapper> _counters;

        public PerfCounterService()
        {
            _counters = new List<PerfCounterWrapper>();

            _counters.Add(new PerfCounterWrapper("Processor", "Processor", "% Processor Time", "_Total"));

            _counters.Add(new PerfCounterWrapper("Paging", "Memory", "Pages/Sec"));

            _counters.Add(new PerfCounterWrapper("Disk", "PhysicalDisk", "% Disk Time", "_Total"));
        }

        public dynamic GetResults()
        {
            return _counters.Select(c => new { name = c.Name, value = c.Value});
        }
    }
}