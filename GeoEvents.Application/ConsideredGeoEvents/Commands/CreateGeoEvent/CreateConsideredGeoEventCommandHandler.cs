using MediatR;
using GeoEvents.Domain;
using GeoEvents.Application.Interfaces;

namespace GeoEvents.Application.ConsideredGeoEvents.Commands.CreateGeoEvent
{
    //CreateGeoEventCommand - type queries, Guid - type response
    public class CreateConsideredGeoEventCommandHandler : IRequestHandler<CreateConsideredGeoEventCommand, Guid>
    {
        private readonly IGeoEventsDbContext _dbContext;

        public CreateConsideredGeoEventCommandHandler(IGeoEventsDbContext dbContext) =>
            _dbContext = dbContext;

        //LOGIC handle command
        public async Task<Guid> Handle(CreateConsideredGeoEventCommand request,
            CancellationToken cancellationToken)
        {
            var geoEvent = new GeoEvent
            {
                UserId = request.UserId,
                Id = Guid.NewGuid(),
                Title = request.Title,
                Details = request.Details,
                Latitude = request.Latitude,
                Longitude = request.Longitude,

                CreationDate = DateTime.Now,
                EditDate = null
            };

            await _dbContext.ConsideredGeoEvents.AddAsync(geoEvent, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return geoEvent.Id;
        }
    }
}
