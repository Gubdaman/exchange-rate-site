namespace ExchangeRateBackend.Models.Service
{
    public class ExchangeRate
    {
        public string Currency { get; set; } = string.Empty;

        public double Value { get; set; }
    }
}
