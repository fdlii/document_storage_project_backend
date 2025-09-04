using DocumentStorage.Application.Services;
using DocumentStorage.API.Contracts;

namespace DocumentStorage.API.Endpoints
{
    public static class UserEndpoints
    {
        public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app) {
            app.MapPost("register", Register);
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
    }
}
