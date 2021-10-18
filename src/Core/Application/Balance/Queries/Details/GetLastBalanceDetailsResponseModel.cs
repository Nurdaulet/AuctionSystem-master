

namespace Application.Balance.Queries.Details
{
    using Domain.Entities;
    using global::Common.AutoMapping.Interfaces;

    public class GetLastBalanceDetailsResponseModel : IMapWith<SaldoUser>
    {
        public int Id { get; set; }
        public decimal Saldo { get; set; }
        public string UserId { get; set; }
    }
}
