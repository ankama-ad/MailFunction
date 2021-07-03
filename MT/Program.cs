using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace MT
{
    // Copyright (c) .NET Foundation. All rights reserved.
    // Licensed under the MIT License. See License.txt in the project root for license information.
    class Program
    {
        static async Task Main(string[] args)
        {
            string sqlConnectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
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
        }
    }

}
