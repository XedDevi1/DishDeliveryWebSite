using DishDeliveryWebSite.Extensions;
using DishDeliveryWebSite.Helpers;
using DishDeliveryWebSite.Middlewares;
using DishDeliveryWebSite.Persistence;
using DishDeliveryWebSite.Services;
using Microsoft.EntityFrameworkCore;

namespace DishDeliveryWebSite
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.

            builder.Services.AddTransient<ExceptionHandlerMiddleware>();
            builder.Services.AddDbContext<DishDeliveryContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddIdentityService(builder.Configuration);
            builder.Services.AddScoped<TokenService>();
            builder.Services.AddScoped<RefreshTokenService>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            await app.Services.ApplyMigrationsForDbContext<DishDeliveryContext>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}