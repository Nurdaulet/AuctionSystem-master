namespace Api.Controllers
{
    using System.Threading.Tasks;
    using Api.Common;
    using Application.Common.Models;
    using Application.Options.Queries.List;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using SwaggerExamples;
    using Swashbuckle.AspNetCore.Annotations;

    public class OptionsController : BaseController
    {
        private const int CachedTimeInMinutes = 3600;

        [HttpGet]
        [Cached(CachedTimeInMinutes)]
        [SwaggerResponse(
            StatusCodes.Status200OK,
            SwaggerDocumentation.CategoriesConstants.SuccessfulGetRequestMessage,
            typeof(MultiResponse<ListOptionsResponseModel>))]
        [SwaggerResponse(
            StatusCodes.Status404NotFound,
            SwaggerDocumentation.CategoriesConstants.BadRequestDescriptionMessage,
            typeof(NotFoundErrorModel))]
        public async Task<IActionResult> Get()
        {
            var result = await this.Mediator.Send(new ListOptionsQuery());
            return this.Ok(result);
        }
    }
}