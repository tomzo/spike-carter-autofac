using System.IO;
using Microsoft.AspNetCore.Hosting;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using MyCarterApp;

namespace MyCarterApp
{
    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder ConfigureWebHostBuilder(this IWebHostBuilder builder) {
            return builder.UseContentRoot(Directory.GetCurrentDirectory())                
                .ConfigureServices(services => services.AddAutofac())
                .UseStartup<Startup>()
                .UseUrls("http://0.0.0.0:8080");
        }
    }
}