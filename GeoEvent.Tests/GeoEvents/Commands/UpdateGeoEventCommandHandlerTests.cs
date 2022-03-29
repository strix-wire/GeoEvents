using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GeoEvents.Application.Common.Exceptions;
using GeoEvents.Application.GeoEvents.Commands.UpdateGeoEvent;
using GeoEvents.Tests.Common;
using Xunit;

namespace GeoEvents.Tests.GeoEvents.Commands
{
    //1. Метод - проверка успешного обновления GeoEvent
    //2. Падение при неверном id
    //3. Падение при неверном id юзера
    public class UpdateGeoEventCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateGeoEventCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateConsideredGeoEventCommandHandler(Context);
            var updatedTitle = "new title";

            // Act
            await handler.Handle(new UpdateConsideredGeoEventCommand
            {
                Id = GeoEventsContextFactory.GeoEventIdForUpdate,
                UserId = GeoEventsContextFactory.UserBId,
                Title = updatedTitle
            }, CancellationToken.None);
            
            // Assert
            Assert.NotNull(await Context.GeoEvents.SingleOrDefaultAsync(note =>
                note.Id == GeoEventsContextFactory.GeoEventIdForUpdate &&
                note.Title == updatedTitle));
        }

        [Fact]
        public async Task UpdateGeoEventCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateConsideredGeoEventCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateConsideredGeoEventCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = GeoEventsContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdateGeoEventCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdateConsideredGeoEventCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateConsideredGeoEventCommand
                    {
                        Id = GeoEventsContextFactory.GeoEventIdForUpdate,
                        UserId = GeoEventsContextFactory.UserAId
                    },
                    CancellationToken.None);
            });
        }
    }
}
