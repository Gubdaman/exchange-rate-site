using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExchangeRateBackend.Models.Database
{
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<SavedExchangeRateModel> SavedExchangeRates { get; set; } = new List<SavedExchangeRateModel>();
    }
}
