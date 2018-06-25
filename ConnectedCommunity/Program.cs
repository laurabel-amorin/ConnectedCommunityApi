using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConnectedCommunity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (Debugger.IsAttached || args.Contains("--console"))
            {
                BuildWebHost(args).Run();
            }
            else
            {
                BuildWebHost(args).RunAsService();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
