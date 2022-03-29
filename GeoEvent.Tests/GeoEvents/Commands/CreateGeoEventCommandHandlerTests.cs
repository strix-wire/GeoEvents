using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GeoEvents.Application.GeoEvents.Commands.CreateGeoEvent;
using GeoEvents.Tests.Common;
using Xunit;

//Тесты для того, что разработано в GeoEvents.Application
namespace GeoEvents.Tests.GeoEvents.Commands
{
    public class CreateGeoEventCommandHandlerTests : TestCommandBase
    {
        //[Fact] - метод который должен быть запущен во время прогона теста
        [Fact]
        public async Task CreateGeoEventCommandHandler_Success()
        {
            //Arrange - подготовка данных для теста
            // Arrange
            var handler = new CreateConsideredGeoEventCommandHandler(Context);
            var noteName = "note name";
            var noteDetails = "note details";

            //Act - логика
            // Act
            var noteId = await handler.Handle(
                new CreateConsideredGeoEventCommand
                {
                    Title = noteName,
                    Details = noteDetails,
                    UserId = GeoEventsContextFactory.UserAId
                },
                CancellationToken.None);

            //Assert - проверка результата
            // Assert
            //Проверяем, что тестовый контекст содержит заметку с заданными id, названием и деталями
            Assert.NotNull(
                await Context.GeoEvents.SingleOrDefaultAsync(note =>
                    note.Id == noteId && note.Title == noteName &&
                    note.Details == noteDetails));
        }
    }
}
