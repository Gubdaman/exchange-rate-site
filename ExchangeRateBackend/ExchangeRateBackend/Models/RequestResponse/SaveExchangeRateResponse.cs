namespace ExchangeRateBackend.Models.RequestResponse
{
    public class SaveExchangeRateResponse
    {
        public string Id { get; set; }
        public string Currency { get; set; }
        public string Comment { get; set; }
        public double ExchangeRate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
