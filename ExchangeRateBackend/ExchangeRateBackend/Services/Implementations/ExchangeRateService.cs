using AutoMapper;
using ExchangeRateBackend.Database;
using ExchangeRateBackend.Models.Database;
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

        public async Task SaveExchangeRateAsync()
        {
            using (var db = new DatabaseContext())
            {
                db.Database.EnsureCreated();

                var model = db.SavedExchangeRates.Add(new SavedExchangeRateModel()
                {
                    CreatedAt = DateTime.UtcNow,
                    ExchangeRate = 1.1d,
                    Comment = "",
                    Currency = "USD",
                    UpdatedAt = DateTime.UtcNow,
                });
                db.SaveChanges();
            }
            
        }

        public async Task GetSavedExchangeRatesAsync()
        {
            using (var db = new DatabaseContext())
            {
                var models = db.SavedExchangeRates.ToList();
            }
        }

        public async Task DeleteSavedExchangeRateAsync()
        {
            throw new NotImplementedException();
        }

        public async Task ExchangeCurrenciesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ExchangeRate>> GetCurrentExchangeRatesAsync()
        {
            var currentExchangeRates = await _MNBDataService.GetCurrentExchangeRatesAsync();
            var exchangeRates = _mapper.Map<List<ExchangeRate>>(currentExchangeRates.Day.Rate);
            return exchangeRates;
        }

        public async Task GetSavedExchangeRateByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateSavedExchangeRate()
        {
            throw new NotImplementedException();
        }
    }
}
