using ExchangeRateBackend.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ExchangeRateBackend.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base()
        {

        }

        public DbSet<SavedExchangeRateModel> SavedExchangeRates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("YourConnectionStringEnvVar"));
            //"DatabaseContext": "Server=localhost;Database=myDataBase;User Id=SA;Password=DebugPassword123!;"
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SchoolDb;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer("Server=localhost;Database=myDataBase;User Id=SA;Password=DebugPassword123!;Trusted_Connection=True;");
        }
    }
}
