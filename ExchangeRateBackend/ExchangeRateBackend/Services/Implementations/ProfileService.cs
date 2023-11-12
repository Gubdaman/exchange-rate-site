using ExchangeRateBackend.Database;
using ExchangeRateBackend.Models.Service;
using ExchangeRateBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExchangeRateBackend.Services.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly ILogger<ProfileService> _logger;

        public ProfileService(ILogger<ProfileService> logger)
        {
            _logger = logger;
        }
        public async Task<LoginData> Login(LoginData loginData)
        {
            using (var db = new DatabaseContext())
            {
                var model = await db.Users.FirstOrDefaultAsync(t => t.Username == loginData.Username);
                if(model != null && model.Username.Equals(loginData.Username) && model.Password.Equals(loginData.Password)) {
                    loginData.Id = model.Id;
                    return loginData;
                }
                else
                {
                    var errorMessage = "Invalid login data!";
                    _logger.LogError(errorMessage);
                    throw new Exception(errorMessage);
                }
            }
        }

        public async Task<LoginData> Register(LoginData loginData)
        {
            using (var db = new DatabaseContext())
            {
                var model = await db.Users.FirstOrDefaultAsync(t => t.Username == loginData.Username);
                if (model == null) {
                    var newUser = await db.Users.AddAsync(new Models.Database.UserModel()
                    {
                        Password = loginData.Password,
                        Username = loginData.Username,
                    });
                    await db.SaveChangesAsync();
                    return loginData;
                }
                else
                {
                    var errorMessage = "User already exists!";
                    _logger.LogError(errorMessage);
                    throw new Exception(errorMessage);
                }
            }
        }
    }
}
