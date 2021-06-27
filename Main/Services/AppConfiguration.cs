using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MailFunction.Services
{
    public static class AppConfiguration
    {
        public static readonly IConfigurationRoot Configuration;

        static AppConfiguration()
        {
            Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }
    }
}
