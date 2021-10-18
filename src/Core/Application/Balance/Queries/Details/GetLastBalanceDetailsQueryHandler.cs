
namespace Application.Balance.Queries.Details
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Common.Interfaces;
    using Common.Models;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetLastBalanceDetailsQueryHandler : IRequestHandler<GetLastBalanceDetailsQuery,
        Response<GetLastBalanceDetailsResponseModel>>
    {
        private readonly IAuctionSystemDbContext context;
        private readonly IMapper mapper;

        public GetLastBalanceDetailsQueryHandler(IAuctionSystemDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Response<GetLastBalanceDetailsResponseModel>> Handle(GetLastBalanceDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var saldo = await this.context
                .SaldoUsers
                .Where(b => b.UserId == request.UserId)
                .OrderByDescending(b => b.Saldo)
                .ProjectTo<GetLastBalanceDetailsResponseModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            return new Response<GetLastBalanceDetailsResponseModel>(saldo);
        }
    }
}
