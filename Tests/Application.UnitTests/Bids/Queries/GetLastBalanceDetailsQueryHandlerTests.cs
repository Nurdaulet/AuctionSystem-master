namespace Application.UnitTests.Bids.Queries
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Bids.Queries.Details;
    using AutoMapper;
    using Common.Interfaces;
    using Common.Models;
    using Domain.Entities;
    using FluentAssertions;
    using Setup;
    using Xunit;

    [Collection("QueryCollection")]
    public class GetLastBalanceDetailsQueryHandlerTests
    {
        private readonly IAuctionSystemDbContext context;
        private readonly IMapper mapper;

        public GetLastBalanceDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            this.context = fixture.Context;
            this.mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetHighestBidDetails_Should_Return_CorrectEntityAndModel()
        {
            var handler = new GetHighestBidDetailsQueryHandler(this.context, this.mapper);
            var result = await handler.Handle(new GetHighestBidDetailsQuery(DataConstants.SampleItemId), CancellationToken.None);

            result
                .Should()
                .BeOfType<Response<GetHighestBidDetailsResponseModel>>();
        }
    }
}