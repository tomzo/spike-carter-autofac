namespace MyCarterApp
{
    using System.IO;
    using Microsoft.AspNetCore.Hosting;

    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .ConfigureWebHostBuilder()
                .Build();

            host.Run();
        }
    }
}
