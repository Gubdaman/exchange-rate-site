using ExchangeRateBackend.Models.Service;

namespace ExchangeRateBackend.Services.Interfaces
{
    public interface IProfileService
    {
        public Task<LoginData> Register(LoginData loginData);
        public Task<LoginData> Login(LoginData loginData);
    }
}
