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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SchoolDb;Trusted_Connection=True;");
        }
    }
}
