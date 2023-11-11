using ExchangeRateBackend.Models.MNB;

namespace ExchangeRateBackend.Services.Interfaces
{
    public interface IMNBDataService
    {
        public Task<MNBCurrencies> GetCurrenciesAsync();
        public Task<MNBExchangeRates> GetExchangeRatesAsync();
        public Task<MNBCurrentExchangeRates> GetCurrentExchangeRatesAsync();
        public Task<MNBStoredInterval> GetDateIntervalAsync();
        public Task<MNBExchangeRatesQueryValues> GetInfoAsync();
    }
}