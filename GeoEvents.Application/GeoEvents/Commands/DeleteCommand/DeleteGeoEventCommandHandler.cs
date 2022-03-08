using MediatR;
using GeoEvents.Application.Interfaces;
using GeoEvents.Application.Common.Exceptions;
using GeoEvents.Domain;

namespace GeoEvents.Application.GeoEvents.Commands.DeleteCommand
{
    public class DeleteGeoEventCommandHandler
        : IRequestHandler<DeleteGeoEventCommand>
    {
        private readonly IGeoEventsDbContext _dbContext;

        public DeleteGeoEventCommandHandler(IGeoEventsDbContext dbContext) =>
            _dbContext = dbContext;

        //Unit - empty response from MediatR
        public async Task<Unit> Handle(DeleteGeoEventCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.GeoEvents
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(GeoEvent),request.Id);
            }

            _dbContext.GeoEvents.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
