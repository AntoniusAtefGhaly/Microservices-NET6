using MediatR;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Ordering.Application.Handlers;
using Ordering.Core.Repositories;
using Ordering.Core.Repositories.Base;
using Ordering.Infrastrcture.Data;
using Ordering.Infrastrcture.Repositories;
using Ordering.Infrastrcture.Repositories.Base;

using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace Ordering.Api
{
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

            //            var connectionString = builder.Configuration.GetConnectionString("OrderConnection");

            builder.Services.AddDbContext<OrderContext>(
               c => c.UseSqlServer(builder.Configuration.GetConnectionString("OrderConnection")),
               ServiceLifetime.Singleton);

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
            builder.Services.AddTransient<IOrderRepository, OrderRepository>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CheckoutOrderHandler).GetTypeInfo().Assembly));

            // builder.Services.AddMediatR(typeof(CheckoutOrderHandler).GetTypeInfo().Assembly);
            //builder.services.AddMediatR(typeof(CheckoutOrderHandler).GetTypeInfo().Assembly);
            //builder.Services.AddMediatR(typeof(CheckoutOrderHandler).GetTypeInfo().Assembly);
            //builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "order api", Version = "v1" });
            });

            //builder.Services.AddSingleton<IRabbitMQConnection>(sp =>
            //{
            //    var factory = new ConnectionFactory()
            //    {
            //        HostName = Configuration["EventBus:HostName"]
            //    };
            //    if (!string.IsNullOrEmpty(Configuration["EventBus:UserName"]))
            //    {
            //        factory.UserName = Configuration["EventBus:UserName"];
            //    }
            //    if (!string.IsNullOrEmpty(Configuration["EventBus:PassWord"]))
            //    {
            //        factory.UserName = Configuration["EventBus:PassWord"];
            //    }
            //    return new RabbitMQConnection(factory);
            //}
            //);
            //services.AddSingleton<EventBusRabbitMQConsumer>();

            /* seed DB */

            var services = builder.Services;
            var serviceProvider = services.BuildServiceProvider();
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            var orderContext = serviceProvider.GetRequiredService<OrderContext>();

            try
            {
                OrderContextSeed.SeedAsync(orderContext, loggerFactory);
            }
            catch (Exception exception)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(exception.Message);
            }

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
}