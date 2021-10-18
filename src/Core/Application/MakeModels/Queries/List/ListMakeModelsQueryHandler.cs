namespace Application.Categories.Queries.List
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

    public class ListMakeModelsQueryHandler : IRequestHandler<ListMakeModelsQuery, MultiResponse<ListCategoriesResponseModel>>
    {
        private readonly IAuctionSystemDbContext context;
        private readonly IMapper mapper;

        public ListMakeModelsQueryHandler(IAuctionSystemDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<MultiResponse<ListCategoriesResponseModel>> Handle(ListMakeModelsQuery request,
            CancellationToken cancellationToken)
        {
            var categories = await this.context
                .Categories
                .ProjectTo<ListCategoriesResponseModel>(this.mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new MultiResponse<ListCategoriesResponseModel>(categories);
        }
    }
}