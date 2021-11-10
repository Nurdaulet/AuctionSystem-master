

namespace Api.Controllers
{

    using Api.SwaggerExamples;
    using Application.TopUp.Commands;
    using Application.TopUp.Queries;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using System.Threading.Tasks;

    [Authorize]
    public class TopUpController : BaseController
    {
        [HttpGet]
        [Route("getTopUpList/{userId?}")]
        [SwaggerResponse(
            StatusCodes.Status200OK,
            SwaggerDocumentation.BalanceConstants.GetLastBalanceDescriptionMessage,
            typeof(UserTopUpListResponseModel))]
        public async Task<IActionResult> TopUp(string userId)
        {
            if(string.IsNullOrEmpty(userId)){
                return this.NotFound();
            }
            var result = await this.Mediator.Send(new UserTopUpListQuery(userId));
            return this.Ok(result);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status204NoContent,
            SwaggerDocumentation.BidConstants.SuccessfulPostRequestDescriptionMessage)]
        [SwaggerResponse(
            StatusCodes.Status400BadRequest,
            SwaggerDocumentation.BidConstants.BadRequestOnPostRequestDescriptionMessage,
            typeof(BadRequestErrorModel))]
        [SwaggerResponse(
            StatusCodes.Status401Unauthorized,
            SwaggerDocumentation.UnauthorizedDescriptionMessage)]
        [SwaggerResponse(
            StatusCodes.Status404NotFound,
            SwaggerDocumentation.BidConstants.NotFoundOnPostRequestDescriptionMessage,
            typeof(NotFoundErrorModel))]
        public async Task<IActionResult> Post([FromBody] UserTopUpCommand model)
        {
            await this.Mediator.Send(model);
            return this.NoContent();
        }
    }
}