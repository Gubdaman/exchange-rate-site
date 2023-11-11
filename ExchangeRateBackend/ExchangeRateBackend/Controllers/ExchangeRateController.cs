using AutoMapper;
using ExchangeRateBackend.Models.MNB;
using ExchangeRateBackend.Models.RequestResponse;
using ExchangeRateBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRateBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeRateController : ControllerBase
    {
        private readonly ILogger<ExchangeRateController> _logger;
        private readonly IMNBDataService _MNBDataService;
        private readonly IExchangeRateService _exchangeRateService;
        private readonly IMapper _mapper;

        public ExchangeRateController(ILogger<ExchangeRateController> logger, IMNBDataService MNBDataService, IExchangeRateService exchangeRateService, IMapper mapper)
        {
            _logger = logger;
            _MNBDataService = MNBDataService;
            _exchangeRateService = exchangeRateService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/current-exchange-rates")]
        public async Task<GetCurrentExchangeRatesResponse> GetCurrenciesAsync()
        {
            var res = await _exchangeRateService.GetCurrentExchangeRatesAsync();
            return new GetCurrentExchangeRatesResponse()
            {
                ExchangeRates = _mapper.Map<List<ExchangeRateResponse>>(res)
            };
        }

        [HttpGet]
        [Route("/save-exchange-rate")]
        public async Task<string> SaveExchangeRate()
        {
            await _exchangeRateService.SaveExchangeRateAsync();
            return "test";
        }

        [HttpGet]
        [Route("/saved")]
        public async Task<string> GetSavedAsync()
        {
            await _exchangeRateService.GetSavedExchangeRatesAsync();
            return "test";
        }

        [HttpGet]
        [Route("/saved/{id}")]
        public async Task<GetCurrentExchangeRatesResponse> GetSavedByIdAsync(int id)
        {
            await _exchangeRateService.GetSavedExchangeRateByIdAsync(id);
            return new GetCurrentExchangeRatesResponse()
            {
                ExchangeRates = _mapper.Map<List<ExchangeRateResponse>>("asd")
            };
        }

        [HttpGet]
        [Route("/t-currency")]
        public async Task<MNBCurrencies> GetCurrenciesAsync2()
        {
            var res = await _MNBDataService.GetCurrenciesAsync();
            return res;
        }

        [HttpGet]
        [Route("/t-info")]
        public async Task<MNBExchangeRatesQueryValues> GetInfoAsync2()
        {
            var res = await _MNBDataService.GetInfoAsync();
            return res;
        }

        [HttpGet]
        [Route("/t-exchange-rates")]
        public async Task<MNBExchangeRates> GetExchangeRatesAsync2()
        {
            var res = await _MNBDataService.GetExchangeRatesAsync();
            return res;
        }

        [HttpGet]
        [Route("/t-current-exchange-rates")]
        public async Task<MNBCurrentExchangeRates> GetCurrentExchangeRatesAsync2()
        {
            var res = await _MNBDataService.GetCurrentExchangeRatesAsync();
            return res;
        }

        [HttpGet]
        [Route("/t-date-interval")]
        public async Task<MNBStoredInterval> GetDateIntervalAsync2()
        {
            var res = await _MNBDataService.GetDateIntervalAsync();
            return res;
        }
    }
}