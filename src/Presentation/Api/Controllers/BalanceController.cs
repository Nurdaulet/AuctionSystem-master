

namespace Api.Controllers
{

    using Api.SwaggerExamples;
    using Application.Balance.Queries.Details;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using System.Threading.Tasks;

    [Authorize]
    public class BalanceController : BaseController
    {
        [HttpGet]
        [Route("getLastBalance/{userId?}")]
        [SwaggerResponse(
            StatusCodes.Status200OK,
            SwaggerDocumentation.BalanceConstants.GetLastBalanceDescriptionMessage,
            typeof(GetLastBalanceDetailsResponseModel))]
        public async Task<IActionResult> GetLastBalance(string userId)
        {
            var result = await this.Mediator.Send(new GetLastBalanceDetailsQuery(userId));
            return this.Ok(result);
        }
    }
}