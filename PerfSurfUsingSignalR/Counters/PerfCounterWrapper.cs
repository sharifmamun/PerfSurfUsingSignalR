using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace PerfSurfUsingSignalR.Counters
{
    public class PerfCounterWrapper
    {
        public PerfCounterWrapper(string name, string category, string counter, string instance = "")
        {
            _counter = new PerformanceCounter(category, counter, instance, readOnly: true);
        }

        public string Name { get; set; }

        public float Value => _counter.NextValue();

        PerformanceCounter _counter;
    }
}