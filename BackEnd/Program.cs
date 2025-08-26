namespace BackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigins", policy =>
                {
                    policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                });
            });

            var app = builder.Build();

            app.UseCors("AllowOrigins");

            app.MapGet("/", () => "Hello World!");

            app.MapPost("/login", (User user) => { 
                return Results.StatusCode(200);
            });

            app.Run();
        }
    }
}
