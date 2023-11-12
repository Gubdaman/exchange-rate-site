using System.ComponentModel.DataAnnotations;

namespace ExchangeRateBackend.Models.RequestResponse
{
    public class SaveExchangeRateRequest
    {
        public int UserId { get; set; }
        public string Currency { get; set; }
        [StringLength(100)]
        public string Comment { get; set; }
        public double ExchangeRate { get; set; }
    }
}
