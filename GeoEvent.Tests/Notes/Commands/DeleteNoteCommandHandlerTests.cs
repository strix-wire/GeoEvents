using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GeoEvents.Application.Common.Exceptions;
using GeoEvents.Application.GeoEvents.Commands.DeleteCommand;
using GeoEvents.Application.GeoEvents.Commands.CreateGeoEvent;
using GeoEvents.Tests.Common;
using Xunit;

namespace GeoEvents.Tests.GeoEvents.Commands
{
    //Если id заметки неверный, то выбрасывается исключение
    //Если id пользователя который пытается удалить нессответствует id пользователя
    //который указан в самой заметке будет выбрасывать исключение
    public class DeleteGeoEventCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteGeoEventCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteGeoEventCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteGeoEventCommand
            {
                Id = GeoEventsContextFactory.GeoEventIdForDelete,
                UserId = GeoEventsContextFactory.UserAId
            }, CancellationToken.None);

            // Assert
            
            Assert.Null(Context.GeoEvents.SingleOrDefault(note =>
                note.Id == GeoEventsContextFactory.GeoEventIdForDelete));
        }

        [Fact]
        public async Task DeleteGeoEventCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteGeoEventCommandHandler(Context);

            // Act
            // Assert
            //Тип выбрасываемого исключения - NotFoundException,
            //в качестве параметра метода - функция удаления заметки
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteGeoEventCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = GeoEventsContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task DeleteGeoEventCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var deleteHandler = new DeleteGeoEventCommandHandler(Context);
            var createHandler = new CreateGeoEventCommandHandler(Context);
            var noteId = await createHandler.Handle(
                new CreateGeoEventCommand
                {
                    Title = "GeoEventTitle",
                    UserId = GeoEventsContextFactory.UserAId
                }, CancellationToken.None);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(
                    new DeleteGeoEventCommand
                    {
                        Id = noteId,
                        UserId = GeoEventsContextFactory.UserBId
                    }, CancellationToken.None));
        }
    }
}
