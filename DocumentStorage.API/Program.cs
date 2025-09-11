using BackEnd.Requests;
using DocumentStorage.API.Contracts;
using DocumentStorage.API.Endpoints;
using DocumentStorage.API.Extensions;
using DocumentStorage.Application.Interfaces;
using DocumentStorage.Application.Interfaces.Repositories;
using DocumentStorage.Application.Services;
using DocumentStorage.Infrastructure;
using DocumentStorage.Persistance;
using DocumentStorage.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
namespace DocumentStorage.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigins", policy =>
                {
                    policy
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });

            builder.Services.AddDbContext<AppDbContext>(options => 
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            );

            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
            builder.Services.AddApiAuthentithication(builder.Services.BuildServiceProvider().GetRequiredService<IOptions<JwtOptions>>());
            builder.Services.AddAuthorization();

            builder.Services.AddScoped<UserService>();
            builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
            builder.Services.AddScoped<IUsersRepository, UsersRepository>();
            builder.Services.AddScoped<IJwtProvider, JwtProvider>();

            var app = builder.Build();

            app.UseCors("AllowOrigins");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapUserEndpoints();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
