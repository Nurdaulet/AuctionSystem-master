



namespace Application.TopUp.Queries
{
    using Application.Common.Models;
    using MediatR;

    public class UserTopUpListQuery: PaginationFilter, IRequest<PagedResponse<UserTopUpListResponseModel>>
    {
        public UserTopUpListQuery(string userId)
        {
            this.UserId = userId;
        }

        public string UserId { get; }     
    }
}