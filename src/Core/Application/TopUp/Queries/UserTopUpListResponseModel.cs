



namespace Application.TopUp.Queries
{
    using System;
    using Domain.Entities;
    using global::Common.AutoMapping.Interfaces;

    public class UserTopUpListResponseModel : IMapWith<TransactionsNew>
    {
        public string UserId { get; set; }
        public decimal Amount { get; set; }
        public decimal SaldoAccount { get; set; }
        public DateTime Created { get; set; }
    }
}