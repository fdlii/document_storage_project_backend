using BackEnd.Requests;
using DocumentStorage.API.Contracts;
using Microsoft.EntityFrameworkCore;
using DocumentStorage.Persistance;
using DocumentStorage.Persistance.Repositories;
using DocumentStorage.Application.Services;
using DocumentStorage.Application.Interfaces;
using DocumentStorage.Infrastructure;
using DocumentStorage.Application.Interfaces.Repositories;
using DocumentStorage.API.Endpoints;
namespace DocumentStorage.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

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

            builder.Services.AddScoped<UserService>();
            builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
            builder.Services.AddScoped<IUsersRepository, UsersRepository>();

            var app = builder.Build();

            app.UseCors("AllowOrigins");

            app.MapUserEndpoints();

            app.MapGet("/", () => "Hello World!");

            //app.MapPost("/login", async (LoginRequest loginRequest, IUsersRepository usersRepository) => { 
            //    var user = await usersRepository.GetUserByEmailAsync(loginRequest.Email);
            //    if (user != null) { 
            //        return loginRequest.Password == user.PasswordHash ? Results.Ok() : Results.Unauthorized();
            //    }
            //    return Results.Unauthorized();
            //});

            app.Run();
        }

    }
}
