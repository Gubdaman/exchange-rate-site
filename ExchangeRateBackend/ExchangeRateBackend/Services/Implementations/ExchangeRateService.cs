using AutoMapper;
using ExchangeRateBackend.Database;
using ExchangeRateBackend.Models.Database;
using ExchangeRateBackend.Models.Request;
using ExchangeRateBackend.Models.Service;
using ExchangeRateBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExchangeRateBackend.Services.Implementations
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IMNBDataService _MNBDataService;
        private readonly IMapper _mapper;
        private readonly ILogger<ExchangeRateService> _logger;

        public ExchangeRateService(IMNBDataService MNBDataService, IMapper mapper, ILogger<ExchangeRateService> logger)
        {
            _MNBDataService = MNBDataService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<ExchangeRate>> GetCurrentExchangeRatesAsync()
        {
            var currentExchangeRates = await _MNBDataService.GetCurrentExchangeRatesAsync();
            var exchangeRates = _mapper.Map<List<ExchangeRate>>(currentExchangeRates.Day.Rate);
            return exchangeRates;
        }

        public List<SavedExchangeRate> GetSavedExchangeRates(int userId)
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
                var model = await db.SavedExchangeRates.FirstOrDefaultAsync(t => t.Id == id);
                return _mapper.Map<SavedExchangeRate>(model);
            }
        }

        public async Task<double> ExchangeCurrenciesAsync(string to, double amount)
        {
            var exchangeRates = await GetCurrentExchangeRatesAsync();
            var currencyTo = exchangeRates.FirstOrDefault(t => t.Currency.Equals(to));
            if(currencyTo == null)
            {
                var errorMessage = $"Currency not found: {to}";
                _logger.LogError(errorMessage);
                throw new Exception(errorMessage);
            }
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
                db.SavedExchangeRates.Add(newData);
                await db.SaveChangesAsync();
                return _mapper.Map<SavedExchangeRate>(newData);
            }
        }

        public async Task<SavedExchangeRate> UpdateSavedExchangeRateAsync(UpdateExchangeRateRequest data)
        {
            using (var db = new DatabaseContext())
            {
                var model = db.SavedExchangeRates.FirstOrDefault(t => t.Id == data.Id);
                if( model == null)
                {
                    var errorMessage = $"(UpdateSavedExchangeRate) Saved exchange rate with id not found: {data.Id}";
                    _logger.LogError(errorMessage);
                    throw new Exception(errorMessage);
                }
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
                if (model == null)
                {
                    var errorMessage = $"(DeleteSavedExchangeRate) Saved exchange rate with id not found: {id}";
                    _logger.LogError(errorMessage);
                    throw new Exception(errorMessage);
                }
                var asd = db.SavedExchangeRates.Remove(model);
                await db.SaveChangesAsync();
                return true;
            }
        }
    }
}
