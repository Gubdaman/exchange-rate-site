using ExchangeRateBackend.Models.Request;
using ExchangeRateBackend.Models.Service;

namespace ExchangeRateBackend.Services.Interfaces
{
    public interface IExchangeRateService
    {
        Task<List<ExchangeRate>> GetCurrentExchangeRatesAsync();
        List<SavedExchangeRate> GetSavedExchangeRates(int userId);
        Task<SavedExchangeRate> GetSavedExchangeRateByIdAsync(int id);
        Task<double> ExchangeCurrenciesAsync(string to, double amount);
        Task<SavedExchangeRate> SaveExchangeRateAsync(SaveExchangeRateRequest data);
        Task<SavedExchangeRate> UpdateSavedExchangeRateAsync(UpdateExchangeRateRequest data);
        Task<bool> DeleteSavedExchangeRateAsync(int id);
    }
}
