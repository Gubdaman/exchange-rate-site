using System.ComponentModel.DataAnnotations;

namespace ExchangeRateBackend.Models.Request
{
    public class ExchangeRequest
    {
        [Required]
        public string To { get; set; } = string.Empty;
        [Range(0, double.MaxValue)]
        public double Amount { get; set; }
    }
}
