﻿namespace Application.Options.Queries.List
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

    public class ListOptionsQueryHandler : IRequestHandler<ListOptionsQuery, MultiResponse<ListOptionsResponseModel>>
    {
        private readonly IAuctionSystemDbContext context;
        private readonly IMapper mapper;

        public ListOptionsQueryHandler(IAuctionSystemDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<MultiResponse<ListOptionsResponseModel>> Handle(ListOptionsQuery request,
            CancellationToken cancellationToken)
        {
            // var categories = await this.context
            //     .Categories
            //     .Where(x => x.SortId != 0)
            //     .OrderBy(u => u.SortId)
            //     .Take(7)
            //     .Include(c => c.SubCategories)
            //     .ProjectTo<ListOptionsResponseModel>(this.mapper.ConfigurationProvider)
            //     .ToListAsync(cancellationToken);

            return new MultiResponse<ListOptionsResponseModel>(categories);
        }
    }
}