using DishDeliveryWebSite.Extensions;
using DishDeliveryWebSite.Helpers;
using DishDeliveryWebSite.Middlewares;
using DishDeliveryWebSite.Models;
using DishDeliveryWebSite.Persistence;
using DishDeliveryWebSite.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace DishDeliveryWebSite
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddIdentityCore<User>()
                .AddRoles<IdentityRole<int>>()
                .AddUserManager<UserManager<User>>()
                .AddRoleManager<RoleManager<IdentityRole<int>>>()
                .AddEntityFrameworkStores<DishDeliveryContext>();
            builder.Services.AddAuthorization();

            builder.Services.AddTransient<ExceptionHandlerMiddleware>();
            builder.Services.AddDbContext<DishDeliveryContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            builder.Services.AddIdentityService(builder.Configuration);
            builder.Services.AddScoped<TokenService>();
            builder.Services.AddScoped<RefreshTokenService>();
            builder.Services.AddScoped<GetAllDishesService>();
            builder.Services.AddScoped<AddOrderService>();
            builder.Services.AddScoped<GetUserOrders>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "DishDelivery",
                    Description = "WebApiDiplom Swagger",
                    Contact = new OpenApiContact
                    {
                        Name = "Vadim Presman",
                        Email = "vadim.presman@gmail.com",
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            var app = builder.Build();

            app.Services.Seed();
            await app.Services.ApplyMigrationsForDbContext<DishDeliveryContext>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}