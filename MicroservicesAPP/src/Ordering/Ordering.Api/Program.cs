using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Ordering.Core.Repositories;
using Ordering.Core.Repositories.Base;
using Ordering.Infrastrcture.Data;
using Ordering.Infrastrcture.Repositories;
using Ordering.Infrastrcture.Repositories.Base;

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
            //            builder.Services.AddTransient<IOrderRepository, OrderRepository>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //            builder.Services.AddMediatR(typeof(CheckOutOrderHandle).GetTypeInfo().Assembly);
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