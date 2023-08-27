
using Serilog.Events;
using Serilog;
using Organic_Shop_BackEnd.Database;
using Microsoft.EntityFrameworkCore;

namespace Organic_Shop_BackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(path: "c:\\Users\\aaaaa12521aa\\Desktop\\attempt_to_asp-net-core_angular\\log-.txt",
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                rollingInterval: RollingInterval.Day,
                restrictedToMinimumLevel: LogEventLevel.Information
                ).CreateLogger();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<DatabaseContext>();

            builder.Services.AddControllers();

            builder.Services.AddCors(o => 
            {
                o.AddPolicy("AllowAll", builder => 
                { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSerilog();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseAuthorization();


            app.MapControllers();

            try
            {
                Log.Information("Application Is Starting");
                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application Failed to start");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}