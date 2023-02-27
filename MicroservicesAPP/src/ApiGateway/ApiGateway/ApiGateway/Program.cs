using Microsoft.AspNetCore.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ApiGateway
{
    public class Program
    {
        public static async void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            builder.Services.AddOcelot();

            //            Host.CreateDefaultBuilder(args)
            //    .ConfigureWebHostDefaults(webBuilder =>
            //    {
            //    })
            //.ConfigureAppConfiguration((hostingContext, config) =>
            //{
            //    config.AddJsonFile("ocelot.json");
            //});

            builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("ocelot.json");
            });

            // app.MapGet("/", () => "Hello World!");

            await app.UseOcelot();
            app.Run();
        }
    }
}