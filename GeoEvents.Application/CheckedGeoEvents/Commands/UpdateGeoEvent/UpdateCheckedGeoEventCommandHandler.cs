using MediatR;
using GeoEvents.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using GeoEvents.Application.Common.Exceptions;

namespace GeoEvents.Application.CheckedGeoEvents.Commands.UpdateGeoEvent
{
    public class UpdateCheckedGeoEventCommandHandler : IRequestHandler<UpdateCheckedGeoEventCommand>
    {
        private readonly IGeoEventsDbContext _dbContext;

        public UpdateCheckedGeoEventCommandHandler(IGeoEventsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateCheckedGeoEventCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.CheckedGeoEvents.FirstOrDefaultAsync(geoEvent =>
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
            entity.Latitude = request.Latitude;
            entity.Longitude = request.Longitude;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
