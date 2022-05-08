using MediatR;
using GeoEvents.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using GeoEvents.Application.Common.Exceptions;

namespace GeoEvents.Application.ConsideredGeoEvents.Commands.UpdateGeoEvent
{
    public class UpdateConsideredGeoEventCommandHandler : IRequestHandler<UpdateConsideredGeoEventCommand>
    {
        private readonly IGeoEventsDbContext _dbContext;

        public UpdateConsideredGeoEventCommandHandler(IGeoEventsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateConsideredGeoEventCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.ConsideredGeoEvents.FirstOrDefaultAsync(geoEvent =>
                geoEvent.Id == request.Id, cancellationToken);

            //If GeoEvents not found or uncorrect id
            if (entity == null)
            {
                throw new NotFoundException(nameof(GeoEvents), request.Id);
            }

            //If entity is exist then update her 
            entity.Details = request.Details;
            entity.Title = request.Title;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
