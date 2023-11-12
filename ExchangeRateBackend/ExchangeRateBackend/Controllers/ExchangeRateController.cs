using AutoMapper;
using ExchangeRateBackend.Models.Request;
using ExchangeRateBackend.Models.RequestResponse;
using ExchangeRateBackend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRateBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
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
        [Route("current")]
        public async Task<List<ExchangeRateResponse>> GetCurrentExchangeRatesAsync()
        {
            _logger.LogInformation("GetCurrentExchangeRatesAsync Start");
            var rates = await _exchangeRateService.GetCurrentExchangeRatesAsync();
            return _mapper.Map<List<ExchangeRateResponse>>(rates);
        }

        [HttpPut]
        [Route("save")]
        public async Task<SaveExchangeRateResponse> SaveExchangeRate(SaveExchangeRateRequest request)
        {
            _logger.LogInformation("SaveExchangeRate Start");
            var response = await _exchangeRateService.SaveExchangeRateAsync(request);
            return _mapper.Map<SaveExchangeRateResponse>(response);
        }

        [HttpPost]
        [Route("update")]
        public async Task<SaveExchangeRateResponse> UpdateSavedExchangeRate(UpdateExchangeRateRequest request)
        {
            _logger.LogInformation("UpdateSavedExchangeRate Start");
            var response = await _exchangeRateService.UpdateSavedExchangeRateAsync(request);
            return _mapper.Map<SaveExchangeRateResponse>(response);
        }

        [HttpGet]
        [Route("saved/{userId}")]
        public List<SaveExchangeRateResponse> GetSaved(int userId)
        {
            _logger.LogInformation("GetSaved Start");
            var response = _exchangeRateService.GetSavedExchangeRates(userId);
            return _mapper.Map<List<SaveExchangeRateResponse>>(response);
        }

        [HttpPost]
        [Route("exchange/")]
        public async Task<double> ExchangeAsync(ExchangeRequest request)
        {
            _logger.LogInformation("ExchangeAsync Start");
            var response = await _exchangeRateService.ExchangeCurrenciesAsync(request.To, request.Amount);
            return response;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            _logger.LogInformation("DeleteAsync Start");
            var response = await _exchangeRateService.DeleteSavedExchangeRateAsync(id);
            return response;
        }
    }
}