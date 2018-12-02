namespace MyCarterApp
{
    using System.IO;
    using Microsoft.AspNetCore.Hosting;
    using Autofac.Extensions.DependencyInjection;
    using Autofac;

    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()
                .ConfigureServices(services => services.AddAutofac())
                .UseStartup<Startup>()
                .UseUrls("http://0.0.0.0:8080")
                .Build();

            host.Run();
        }
    }
}
