using Catalog.API.Data.Interfaces;
using Catalog.API.Data;
using Catalog.API.Interfaces.Repositories;
using Catalog.API.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Catalog.API
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
            var connectionString = builder.Configuration.GetConnectionString("CatalogDatabaseSettings");
            builder.Services.AddDbContext<CatalogContext>(x => x.UseSqlServer(connectionString));
            //var conn = "";
            //            builder.Services.AddSingleton<ICatalogDatabaseSettings>(sp => sp.GetRequiredService<IOptions<CatalogDatabaseSettings>>().Value);
            builder.Services.AddTransient<ICatalogContext, CatalogContext>();
            builder.Services.AddTransient<ICatalogApi, ProductRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            //var CatalogContext = app.Services.GetRequiredService<CatalogContext>();
            //CatalogContext.Database.MigrateAsync();

            app.Run();
        }
    }
}