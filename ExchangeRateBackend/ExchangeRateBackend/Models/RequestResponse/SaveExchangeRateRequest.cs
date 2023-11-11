namespace ExchangeRateBackend.Models.RequestResponse
{
    public class SaveExchangeRateRequest
    {
        public string Currency { get; set; }
        public string Comment { get; set; }
        public double ExchangeRate { get; set; }
    }
}
