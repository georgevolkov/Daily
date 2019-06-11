using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DailyApp
{
    public class Program : IInterface
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }

    public interface IInterface
    {
    }
}