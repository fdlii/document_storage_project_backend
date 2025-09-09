using DocumentStorage.Application.Services;
using DocumentStorage.API.Contracts;
using BackEnd.Requests;

namespace DocumentStorage.API.Endpoints
{
    public static class UserEndpoints
    {
        public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app) {
            app.MapPost("register", Register);
            app.MapPost("login", Login);
            return app;
        }
        public static async Task<IResult> Register(
            RegisterRequest registerRequest,
            UserService userService)
        {
            if (registerRequest.Password == registerRequest.confirmPassword)
            {
                await userService.Register(registerRequest.Email, registerRequest.Password);
                return Results.Ok();
            }
            return Results.ValidationProblem(new Dictionary<string, string[]>() { { "error", ["Пароли не совпадают."] } });
        }

        public static async Task<IResult> Login(
            LoginRequest loginRequest,
            UserService userService)
        {
            var token = await userService.Login(loginRequest.Email, loginRequest.Password);
            return Results.Ok(token);
        }
    }
}
