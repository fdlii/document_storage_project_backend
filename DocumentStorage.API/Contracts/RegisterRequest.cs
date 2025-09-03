namespace DocumentStorage.API.Contracts
{
    public record RegisterRequest(string Email, string Password, string confirmPassword);
}
