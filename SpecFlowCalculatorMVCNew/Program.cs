using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SpecFlowCalculatorMVCNew
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseContentRoot(@"../../..");
                    webBuilder.UseStartup<Startup>();
                    //webBuilder.UseKestrel();
                    //webBuilder.UseIISIntegration();
                    webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                });
    }
}