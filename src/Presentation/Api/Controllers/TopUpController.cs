

namespace Api.Controllers
{
    using Api.Models;
    using Api.SwaggerExamples;
    using Application;
    using Application.Common.Models;
    using Application.TopUp.Commands;
    using Application.TopUp.Queries;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using System;
    using System.Threading.Tasks;

    [Authorize]
    public class TopUpController : BaseController
    {

        private readonly IMapper mapper;

        public TopUpController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("topUpHistory/{userId}")]
        [SwaggerResponse(
            StatusCodes.Status200OK,
            SwaggerDocumentation.BalanceConstants.GetLastBalanceDescriptionMessage,
            typeof(PagedResponse<UserTopUpListResponseModel>))]
        public async Task<IActionResult> Get([FromQuery] PaginationQuery paginationQuery, string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return this.NotFound();
            }
            var paginationFilter = this.mapper.Map<PaginationFilter>(paginationQuery);
            var myModel = new UserTopUpListQuery(userId);
            myModel.PageNumber = paginationQuery.PageNumber;
            myModel.PageSize = paginationQuery.PageSize;
            Console.WriteLine("passed here");
            var result = await this.Mediator.Send(myModel);
            return this.Ok(result);
        }


        [Authorize(Roles = AppConstants.AdministratorRole)]
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