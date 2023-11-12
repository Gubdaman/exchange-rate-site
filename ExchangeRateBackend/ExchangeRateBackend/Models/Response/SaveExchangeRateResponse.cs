namespace ExchangeRateBackend.Models.RequestResponse
{
    public class SaveExchangeRateResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public double ExchangeRate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
