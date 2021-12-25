namespace Application.Options.Queries.List
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Common.Interfaces;
    using Common.Models;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class ListOptionsQueryHandler : IRequestHandler<ListOptionsQuery, Response<ListOptionsResponseModel>>
    {
        private readonly IAuctionSystemDbContext context;
        private readonly IMapper mapper;

        public ListOptionsQueryHandler(IAuctionSystemDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Response<ListOptionsResponseModel>> Handle(ListOptionsQuery request,
            CancellationToken cancellationToken)
        {
            var badges = await this.context
                .Badges
                .ToListAsync(cancellationToken);
            var bodyTypes = await this.context
                .BodyTypes
                .ToListAsync(cancellationToken);
            var colors = await this.context
                .Colors
                .ToListAsync(cancellationToken);
            var extras = await this.context
                .Extras
                .ToListAsync(cancellationToken);
            var reqionalSpecs = await this.context
                .RegionalSpecs
                .ToListAsync(cancellationToken);
            var fuelTypes = await this.context
                .FuelTypes
                .ToListAsync(cancellationToken);
            var sellerTypes = await this.context
                .SellerTypes
                .ToListAsync(cancellationToken);

            var listOptions = new ListOptionsResponseModel { BodyTypes = bodyTypes };

            return new Response<ListOptionsResponseModel>(listOptions);
        }
    }
}