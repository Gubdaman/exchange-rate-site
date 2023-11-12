using ExchangeRateBackend.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace ExchangeRateBackend.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base()
        {

        }

        public DbSet<SavedExchangeRateModel> SavedExchangeRates { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ExchangeSiteDB;Trusted_Connection=True;");
        }
    }
}
