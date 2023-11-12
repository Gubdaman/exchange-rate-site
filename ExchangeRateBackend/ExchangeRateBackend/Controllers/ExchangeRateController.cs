using AutoMapper;
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
        private readonly IExchangeRateService _exchangeRateService;
        private readonly IMapper _mapper;

        public ExchangeRateController(ILogger<ExchangeRateController> logger, IExchangeRateService exchangeRateService, IMapper mapper)
        {
            _logger = logger;
            _exchangeRateService = exchangeRateService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/current-exchange-rates")]
        public async Task<List<ExchangeRateResponse>> GetCurrenciesAsync()
        {
            var rates = await _exchangeRateService.GetCurrentExchangeRatesAsync();
            return _mapper.Map<List<ExchangeRateResponse>>(rates);
            /*return new GetCurrentExchangeRatesResponse()
            {
                ExchangeRates = _mapper.Map<List<ExchangeRateResponse>>(rates)
            };*/
        }

        [HttpPut]
        [Route("/save-exchange-rate")]
        public async Task<SaveExchangeRateResponse> SaveExchangeRate(SaveExchangeRateRequest request)
        {
            var response = await _exchangeRateService.SaveExchangeRateAsync(request);
            return _mapper.Map<SaveExchangeRateResponse>(response);
        }

        [HttpPost]
        [Route("/update-exchange-rate")]
        public async Task<SaveExchangeRateResponse> UpdateSavedExchangeRate(UpdateExchangeRateRequest request)
        {
            var response = await _exchangeRateService.UpdateSavedExchangeRate(request);
            return _mapper.Map<SaveExchangeRateResponse>(response);
        }

        [HttpGet]
        [Route("/saved")]
        public async Task<List<SaveExchangeRateResponse>> GetSavedAsync()
        {
            var response = await _exchangeRateService.GetSavedExchangeRatesAsync();
            return _mapper.Map<List<SaveExchangeRateResponse>>(response);
        }

        [HttpGet]
        [Route("/saved/{id}")]
        public async Task<SaveExchangeRateResponse> GetSavedByIdAsync(int id)
        {
            var response = await _exchangeRateService.GetSavedExchangeRateByIdAsync(id);
            return _mapper.Map<SaveExchangeRateResponse>(response);
        }

        [HttpPost]
        [Route("/exchange/")]
        public async Task<double> ExchangeAsync(ExchangeRequest request)
        {
            var response = await _exchangeRateService.ExchangeCurrenciesAsync(request.To, request.Amount);
            return response;
        }

        [HttpDelete]
        [Route("/delete/{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _exchangeRateService.DeleteSavedExchangeRateAsync(id);
            return response;
        }
    }
}