﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace PerfSurfUsingSignalR.Hubs
{
    public class PerfHub : Hub
    {
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