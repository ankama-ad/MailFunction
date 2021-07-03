// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Hosting;

namespace Function
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