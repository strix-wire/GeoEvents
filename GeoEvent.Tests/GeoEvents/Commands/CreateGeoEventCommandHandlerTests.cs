using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GeoEvents.Application.ConsideredGeoEvents.Commands.CreateGeoEvent;
using GeoEvents.Tests.Common;
using Xunit;

//Тесты для того, что разработано в GeoEvents.Application
namespace GeoEvents.Tests.GeoEvents.Commands
{
    public class CreateGeoEventCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateGeoEventCommandHandler_Success()
        {
            //Arrange - подготовка данных для теста
            // Arrange
            var handler = new CreateConsideredGeoEventCommandHandler(Context);
            var noteName = "geoEvent name";
            var noteDetails = "geoEvent details";
            var longitude = 56.510645;
            var latitude = 84.9714037;

            //Act - логика
            // Act
            var noteId = await handler.Handle(
                new CreateConsideredGeoEventCommand
                {
                    Title = noteName,
                    Details = noteDetails,
                    Longitude = longitude,
                    Latitude = latitude,
                    UserId = GeoEventsContextFactory.UserAId
                },
                CancellationToken.None);

            //Assert - проверка результата
            // Assert
            //Проверяем, что тестовый контекст содержит заметку с заданными id, названием и деталями
            Assert.NotNull(
                await Context.ConsideredGeoEvents.SingleOrDefaultAsync(note =>
                    note.Id == noteId && note.Title == noteName &&
                    note.Details == noteDetails));
        }
    }
}
