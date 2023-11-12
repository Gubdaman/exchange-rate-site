using AutoMapper;
using ExchangeRateBackend.Database;
using ExchangeRateBackend.Models.Database;
using ExchangeRateBackend.Models.RequestResponse;
using ExchangeRateBackend.Models.Service;
using ExchangeRateBackend.Services.Interfaces;

namespace ExchangeRateBackend.Services.Implementations
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IMNBDataService _MNBDataService;
        private readonly IMapper _mapper;

        public ExchangeRateService(IMNBDataService MNBDataService, IMapper mapper)
        {
            _MNBDataService = MNBDataService;
            _mapper = mapper;
        }

        public async Task<List<ExchangeRate>> GetCurrentExchangeRatesAsync()
        {
            var currentExchangeRates = await _MNBDataService.GetCurrentExchangeRatesAsync();
            var exchangeRates = _mapper.Map<List<ExchangeRate>>(currentExchangeRates.Day.Rate);
            return exchangeRates;
        }

        public async Task<List<SavedExchangeRate>> GetSavedExchangeRatesAsync(int userId)
        {
            using (var db = new DatabaseContext())
            {
                var models = db.SavedExchangeRates.Where(t => t.UserId == userId).ToList();
                return _mapper.Map<List<SavedExchangeRate>>(models);
            }
        }

        public async Task<SavedExchangeRate> GetSavedExchangeRateByIdAsync(int id)
        {
            using (var db = new DatabaseContext())
            {
                var model = db.SavedExchangeRates.FirstOrDefault(t => t.Id == id);
                return _mapper.Map<SavedExchangeRate>(model);
            }
        }

        public async Task<double> ExchangeCurrenciesAsync(string to, double amount)
        {
            var exchangeRates = await GetCurrentExchangeRatesAsync();
            var currencyTo = exchangeRates.FirstOrDefault(t => t.Currency.Equals(to));
            var convertedValue = amount / currencyTo.Value;
            return convertedValue;
        }

        public async Task<SavedExchangeRate> SaveExchangeRateAsync(SaveExchangeRateRequest data)
        {
            using (var db = new DatabaseContext())
            {
                var newData = new SavedExchangeRateModel()
                {
                    CreatedAt = DateTime.UtcNow,
                    ExchangeRate = data.ExchangeRate,
                    Comment = data.Comment,
                    Currency = data.Currency,
                    UpdatedAt = DateTime.UtcNow,
                    UserId = data.UserId,
                };
                var model = db.SavedExchangeRates.Add(newData);
                await db.SaveChangesAsync();
                return _mapper.Map<SavedExchangeRate>(newData);
            }
        }

        public async Task<SavedExchangeRate> UpdateSavedExchangeRate(UpdateExchangeRateRequest data)
        {
            using (var db = new DatabaseContext())
            {
                var model = db.SavedExchangeRates.FirstOrDefault(t => t.Id == data.Id);
                model.UpdatedAt = DateTime.UtcNow;
                model.Comment = data.Comment;
                await db.SaveChangesAsync();
                return _mapper.Map<SavedExchangeRate>(model);
            }
        }

        public async Task<bool> DeleteSavedExchangeRateAsync(int id)
        {
            using (var db = new DatabaseContext())
            {
                var model = db.SavedExchangeRates.FirstOrDefault(t => t.Id == id);
                var asd = db.SavedExchangeRates.Remove(model);
                await db.SaveChangesAsync();
                return true;
            }
        }
    }
}
