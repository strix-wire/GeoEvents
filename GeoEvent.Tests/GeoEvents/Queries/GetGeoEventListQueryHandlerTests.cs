using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using GeoEvents.Application.GeoEvents.Queries.GetGeoEventList;
using GeoEvents.Persistence;
using GeoEvents.Tests.Common;
using Shouldly;
using Xunit;

namespace GeoEvents.Tests.GeoEvents.Queries
{
    [Collection("QueryCollection")]
    public class GetGeoEventListQueryHandlerTests
    {
        private readonly GeoEventsDbContext Context;
        private readonly IMapper Mapper;

        public GetGeoEventListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetGeoEventListQueryHandler_Success()
        {
            // Arrange
            //Т.к. GetGeoEventListQueryHandler - принимает не только Context, но еще и Mapper
            //То создадим вспомогательный класс QueryTestFixture.
            var handler = new GetGeoEventListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetGeoEventListQuery
                {
                    UserId = GeoEventsContextFactory.UserBId
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<GeoEventListVm>();
            result.GeoEvents.Count.ShouldBe(2);
        }
    }
}
