using MediatR;
using GeoEvents.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using GeoEvents.Application.Common.Exceptions;

namespace GeoEvents.Application.GeoEvents.Commands.UpdateGeoEvent
{
    public class UpdateGeoEventCommandHandler : IRequestHandler<UpdateGeoEventCommand>
    {
        private readonly IGeoEventsDbContext _dbContext;

        public UpdateGeoEventCommandHandler(IGeoEventsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateGeoEventCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.GeoEvents.FirstOrDefaultAsync(geoEvent =>
                geoEvent.Id == request.Id, cancellationToken);

            //If GeoEvents not found or uncorrect id
            if (entity == null || entity.UserId != request.UserId)
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
