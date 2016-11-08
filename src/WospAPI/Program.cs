using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace WospAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
#if !DEBUG
            string appPath = Directory.GetCurrentDirectory();
            if (!Directory.GetFiles(appPath).Any(file => file.ToLower().Contains("wospapi.dll")))
            {
                appPath = Path.Combine(appPath, "root");
            }

            var builder = new ConfigurationBuilder()
                    .SetBasePath(appPath)
                    .AddJsonFile("appsettings.production.json");
            var config = builder.Build();            
#endif
            var host = new WebHostBuilder()
#if DEBUG
                .UseKestrel()
#else
                .UseKestrel(options =>
                {
                    options.NoDelay = true;
                    options.UseHttps(Path.Combine(appPath, "wosp.pfx"), config["Data:CertPass"]);
                })
                .UseUrls("http://*:80", "http://*:443")
#endif
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
