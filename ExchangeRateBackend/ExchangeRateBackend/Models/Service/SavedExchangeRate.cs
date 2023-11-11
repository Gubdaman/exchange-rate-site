namespace ExchangeRateBackend.Models.Service
{
    public class SavedExchangeRate
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public string Comment { get; set; }
        public double ExchangeRate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
