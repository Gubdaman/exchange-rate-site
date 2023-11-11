using ExchangeRateBackend.Models.Service;

namespace ExchangeRateBackend.Services.Interfaces
{
    public interface IExchangeRateService
    {
        Task<List<ExchangeRate>> GetCurrentExchangeRatesAsync();
        Task GetSavedExchangeRatesAsync();
        Task GetSavedExchangeRateByIdAsync(int id);
        Task ExchangeCurrenciesAsync();
        Task SaveExchangeRateAsync();
        Task UpdateSavedExchangeRate();
        Task DeleteSavedExchangeRateAsync();
    }
}
