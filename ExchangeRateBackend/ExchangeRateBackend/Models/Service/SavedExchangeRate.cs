namespace ExchangeRateBackend.Models.Service
{
    public class SavedExchangeRate
    {
        int Id { get; set; }
        string Currency { get; set; }
        string Comment { get; set; }
        double ExchangeRate { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}
