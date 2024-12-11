using System.ComponentModel.DataAnnotations;

namespace Mohtawa.Domain.Requests
{
    public class LoginRequest
    {
        [Required]
        [MinLength(5)]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
