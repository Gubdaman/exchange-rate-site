namespace ExchangeRateBackend.Models.RequestResponse
{
    public class ExchangeRateResponse
    {
        public string Currency { get; set; } = string.Empty;

        public double Value { get; set; }
    }
}
