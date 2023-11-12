using System.ComponentModel.DataAnnotations;

namespace ExchangeRateBackend.Models.RequestResponse
{
    public class UpdateExchangeRateRequest
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Comment { get; set; }
    }
}
