using ExchangeRateBackend.Models.RequestResponse;
using ExchangeRateBackend.Models.Service;

namespace ExchangeRateBackend.Services.Interfaces
{
    public interface IExchangeRateService
    {
        Task<List<ExchangeRate>> GetCurrentExchangeRatesAsync();
        Task<List<SavedExchangeRate>> GetSavedExchangeRatesAsync(int userId);
        Task<SavedExchangeRate> GetSavedExchangeRateByIdAsync(int id);
        Task<double> ExchangeCurrenciesAsync(string to, double amount);
        Task<SavedExchangeRate> SaveExchangeRateAsync(SaveExchangeRateRequest data);
        Task<SavedExchangeRate> UpdateSavedExchangeRate(UpdateExchangeRateRequest data);
        Task<bool> DeleteSavedExchangeRateAsync(int id);
    }
}
