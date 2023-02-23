using Basket.API.Data.Interfaces;
using Basket.API.Data;
using Basket.API.Repositories.Interface;
using Basket.API.Repositories;
using Microsoft.EntityFrameworkCore;
using EventBusRabbitMQ;
using RabbitMQ.Client;
using Microsoft.AspNetCore.Hosting;
using EventBusRabbitMQ.Producer;

namespace Basket.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var connectionString = builder.Configuration.GetConnectionString("BasketDatabaseSettings");
        builder.Services.AddDbContext<BasketContext>(x => x.UseSqlServer(connectionString));
        //var conn = "";
        builder.Services.AddTransient<IBasketContext, BasketContext>();
        builder.Services.AddTransient<IBasketRepository, BasketRepository>();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddScoped<EventBusRabbitMQProducer, EventBusRabbitMQProducer>();

        //ConfigurationManager configuration = builder.Configuration;
        //IWebHostEnvironment environment = builder.Environment;

        builder.Services.AddSingleton<IRabbitMQConnection>(
            sp =>
            {
                var factory = new ConnectionFactory();
                factory.HostName = builder.Configuration["EventBus:HostName"];
                if (!string.IsNullOrEmpty(builder.Configuration["EventBus:UserName"]))
                {
                    factory.UserName = builder.Configuration["EventBus:UserName"];
                }
                if (!string.IsNullOrEmpty(builder.Configuration["EventBus:Password"]))
                {
                    factory.Password = builder.Configuration["EventBus:Password"];
                }
                return new RabbitMQConnection(factory);
            }
            );

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}