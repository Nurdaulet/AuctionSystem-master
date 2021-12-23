namespace Application.Options.Queries.List
{
    using Common.Models;
    using MediatR;

    public class ListOptionsQuery : IRequest<MultiResponse<ListOptionsResponseModel>> { }
}