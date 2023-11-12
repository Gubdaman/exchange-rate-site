using System.ComponentModel.DataAnnotations;

namespace ExchangeRateBackend.Models.Request
{
    public class LoginDataRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
