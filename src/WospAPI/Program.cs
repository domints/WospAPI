using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;

namespace WospAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
#if DEBUG
                .UseKestrel()
#else
                .UseKestrel(options =>
                {
                    options.NoDelay = true;
                    options.UseHttps("wosp.crt");
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
