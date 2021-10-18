namespace Application.Categories.Queries.List
{
    using Common.Models;
    using MediatR;

    public class ListMakeModelsQuery : IRequest<MultiResponse<ListCategoriesResponseModel>> { }
}