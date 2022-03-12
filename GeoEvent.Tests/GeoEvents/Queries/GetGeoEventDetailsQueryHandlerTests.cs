using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using Xunit;
using GeoEvents.Tests.Common;
using GeoEvents.Application.GeoEvents.Queries.GetGeoEventDetails;
using GeoEvents.Persistence;

namespace GeoEvents.Tests.GeoEvents.Queries
{
    [Collection("QueryCollection")]
    public class GetGeoEventDetailsQueryHandlerTests
    {
        private readonly GeoEventsDbContext Context;
        private readonly IMapper Mapper;

        public GetGeoEventDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetGeoEventDetailsQueryHandler_Success()
        {
            // Arrange

            var handler = new GetGeoEventDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetGeoEventDetailsQuery
                {
                    UserId = GeoEventsContextFactory.UserBId,
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<GeoEventDetailsVm>();
            result.Title.ShouldBe("Title2");
            result.CreationDate.ShouldBe(DateTime.Today);
        }
    }
}
