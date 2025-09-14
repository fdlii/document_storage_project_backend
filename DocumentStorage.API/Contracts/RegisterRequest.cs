using System.ComponentModel.DataAnnotations;

namespace DocumentStorage.API.Contracts
{
    public record RegisterRequest(
        [Required] string Email,
        [Required] string Password,
        [Required] string confirmPassword
        );
}
