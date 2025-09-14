using System.ComponentModel.DataAnnotations;

namespace BackEnd.Requests
{
    public record LoginRequest(
        [Required] string Email,
        [Required] string Password
        );
}
