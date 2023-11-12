using System.ComponentModel.DataAnnotations;

namespace ExchangeRateBackend.Models.Request
{
    public class UpdateExchangeRateRequest
    {
        [Required]
        public int Id { get; set; }
        [StringLength(100)]
        public string Comment { get; set; } = string.Empty;
    }
}
