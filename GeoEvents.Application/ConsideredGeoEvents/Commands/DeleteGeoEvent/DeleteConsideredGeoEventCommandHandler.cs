using MediatR;
using GeoEvents.Application.Interfaces;
using GeoEvents.Application.Common.Exceptions;
using GeoEvents.Domain;

namespace GeoEvents.Application.ConsideredGeoEvents.Commands.DeleteGeoEvent
{
    public class DeleteConsideredGeoEventCommandHandler
        : IRequestHandler<DeleteConsideredGeoEventCommand>
    {
        private readonly IGeoEventsDbContext _dbContext;

        public DeleteConsideredGeoEventCommandHandler(IGeoEventsDbContext dbContext) =>
            _dbContext = dbContext;

        //Unit - empty response from MediatR
        public async Task<Unit> Handle(DeleteConsideredGeoEventCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.ConsideredGeoEvents
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(GeoEvent),request.Id);
            }

            _dbContext.ConsideredGeoEvents.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
