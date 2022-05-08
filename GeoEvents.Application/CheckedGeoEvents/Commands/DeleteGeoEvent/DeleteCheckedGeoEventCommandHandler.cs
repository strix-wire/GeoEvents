using MediatR;
using GeoEvents.Application.Interfaces;
using GeoEvents.Application.Common.Exceptions;
using GeoEvents.Domain;

namespace GeoEvents.Application.CheckedGeoEvents.Commands.DeleteGeoEvent
{
    public class DeleteCheckedGeoEventCommandHandler
        : IRequestHandler<DeleteCheckedGeoEventCommand>
    {
        private readonly IGeoEventsDbContext _dbContext;

        public DeleteCheckedGeoEventCommandHandler(IGeoEventsDbContext dbContext) =>
            _dbContext = dbContext;

        //Unit - empty response from MediatR
        public async Task<Unit> Handle(DeleteCheckedGeoEventCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.CheckedGeoEvents
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(GeoEventConsidered),request.Id);
            }

            _dbContext.CheckedGeoEvents.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
