namespace ExchangeRateBackend.Models.Service
{
    public class SavedExchangeRate
    {
        public int Id { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public double ExchangeRate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
