using ExchangeRateBackend.Database;
using ExchangeRateBackend.Models.Service;
using ExchangeRateBackend.Services.Interfaces;

namespace ExchangeRateBackend.Services.Implementations
{
    public class ProfileService : IProfileService
    {
        public async Task<LoginData> Login(LoginData loginData)
        {
            using (var db = new DatabaseContext())
            {
                var model = db.Users.FirstOrDefault(t => t.Username == loginData.Username);
                if(model != null && model.Username.Equals(loginData.Username) && model.Password.Equals(loginData.Password)) {
                    loginData.Id = model.Id;
                    return loginData;
                }
                else
                {
                    throw new Exception("Invalid login data!");
                }
            }
        }

        public async Task<LoginData> Register(LoginData loginData)
        {
            using (var db = new DatabaseContext())
            {
                var model = db.Users.FirstOrDefault(t => t.Username == loginData.Username);
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
                    throw new Exception("User already exists!");
                }
            }
        }
    }
}
