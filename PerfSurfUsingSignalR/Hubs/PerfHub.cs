using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using PerfSurfUsingSignalR.Counters;

namespace PerfSurfUsingSignalR.Hubs
{
    public class PerfHub : Hub
    {
        public PerfHub()
        {
            StartCounterCollection();
        }

        private void StartCounterCollection()
        {
            var task = Task.Factory.StartNew(async () =>
            {
                var perfService = new PerfCounterService();
                while(true)
                {
                    var results = perfService.GetResults();
                    Clients.All.newCOunters(results);
                    await Task.Delay(2000);
                }

            }, TaskCreationOptions.LongRunning);
        }

        public void Send(string message)
        {
            if (!string.IsNullOrEmpty(message.Trim()))
            {
                Clients.All.newMessage(
                    Context.User.Identity.Name + " says " + message
                );
            }
        }
    }
}