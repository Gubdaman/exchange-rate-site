using System.ComponentModel.DataAnnotations;

namespace ExchangeRateBackend.Models.Request
{
    public class SaveExchangeRateRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Currency { get; set; } = string.Empty;
        [StringLength(100)]
        public string Comment { get; set; } = string.Empty;
        [Range(0, double.MaxValue)]
        public double ExchangeRate { get; set; }
    }
}
