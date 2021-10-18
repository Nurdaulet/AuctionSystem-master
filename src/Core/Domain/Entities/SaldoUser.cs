

namespace Domain.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class SaldoUser
    {
        public int Id { get; set; }
        public decimal Saldo { get; set; }
        [Required]
        public string UserId { get; set; }
        public AuctionUser User { get; set; }
    }
}