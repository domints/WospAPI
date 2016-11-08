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
            Console.WriteLine(Directory.GetCurrentDirectory());
            Console.WriteLine(string.Join("\r\n", Directory.GetFiles(Directory.GetCurrentDirectory())));
#if !DEBUG
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
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
                    options.UseHttps(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).FullName, "wosp.pfx"), config["Data:CertPass"]);
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
