using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace MailTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // string sqlConnectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
            // #if DEBUG
            //             Debugger.Launch();
            // #endif
            var host = new HostBuilder()
                 .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(s =>
                {

                })
                .Build();

            await host.RunAsync();
            //}



        }



    }
}
