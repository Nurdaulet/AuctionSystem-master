



namespace Application.TopUp.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Helpers;
    using Application.Common.Interfaces;
    using Application.Common.Models;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
    public class UserTopUpListQueryHandler : IRequestHandler<UserTopUpListQuery, PagedResponse<UserTopUpListResponseModel>>
    {
        private readonly IAuctionSystemDbContext context;
        private readonly IMapper mapper;

        public UserTopUpListQueryHandler(IAuctionSystemDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<PagedResponse<UserTopUpListResponseModel>> Handle(UserTopUpListQuery request, CancellationToken cancellationToken)
        {
            Console.WriteLine("passed here 2 and " + request.PageSize);
            var skipCount = (request.PageNumber - 1) * request.PageSize;
            Console.WriteLine("passed here 2.3");
            var queryable = this.context.TransactionsNew.AsQueryable();
            Console.WriteLine("passed here 2.5");
            var totalUsersCount = await this.context.TransactionsNew.CountAsync(cancellationToken);
            Console.WriteLine("passed here 3");
            var users = await queryable.Where(x => x.UserId == request.UserId).OrderByDescending(x => x.Created)
                .Skip(skipCount)
                .Take(request.PageSize)
                .ProjectTo<UserTopUpListResponseModel>(this.mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            var result = PaginationHelper.CreatePaginatedResponse(request, users, totalUsersCount);

            return result;
        }
    }
}