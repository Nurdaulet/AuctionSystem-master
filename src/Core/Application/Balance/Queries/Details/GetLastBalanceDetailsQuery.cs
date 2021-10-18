namespace Application.Balance.Queries.Details
{
    using System;
    using Common.Models;
    using MediatR;

    public class GetLastBalanceDetailsQuery : IRequest<Response<GetLastBalanceDetailsResponseModel>>
    {
        public GetLastBalanceDetailsQuery(string userId)
        {
            this.UserId = userId;
        }

        public string UserId { get; }
    }
}
