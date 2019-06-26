using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TicTacToe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()

                //could enable the capture of errors during server startup and display an error page.
                .CaptureStartupErrors(true)

                .UseStartup<Startup>()

                //indicate whether the host should listen on the standard URL
                .PreferHostingUrls(true)
                .UseUrls("http://localhost:5000")

                //can monitor your applications no matter where or how they run
                //.UseApplicationInsights();

                .Build();
    }
}
