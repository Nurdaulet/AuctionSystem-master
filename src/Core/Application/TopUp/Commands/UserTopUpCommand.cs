



namespace Application.TopUp.Commands
{
    using Domain.Entities;
    using global::Common.AutoMapping.Interfaces;
    using MediatR;
    public class UserTopUpCommand: IRequest, IMapWith<TransactionsNew>
    {
        public decimal Amount { get; set; }
        public string UserId { get; set; }
    }
}