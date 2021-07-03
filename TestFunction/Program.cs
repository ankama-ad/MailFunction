using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker.Configuration;

namespace TestFunction
{
    public class Program
    {
        //public static void Main()
        //{
        //    var host = new HostBuilder()
        //        .ConfigureFunctionsWorkerDefaults()
        //        .Build();

        //    host.Run();
        //}
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