using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExchangeRateBackend.Models.Database
{
    public class SavedExchangeRateModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Currency { get; set; } = string.Empty;
        [StringLength(100)]
        public string Comment { get; set; } = null!;
        public double ExchangeRate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; } = null!;

    }
}
