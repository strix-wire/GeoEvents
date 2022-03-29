using MediatR;
using GeoEvents.Domain;
using GeoEvents.Application.Interfaces;

namespace GeoEvents.Application.CheckedGeoEvents.Commands.CreateGeoEvent
{
    //CreateGeoEventCommand - type queries, Guid - type response
    public class CreateCheckedGeoEventCommandHandler : IRequestHandler<CreateCheckedGeoEventCommand, Guid>
    {
        private readonly IGeoEventsDbContext _dbContext;

        public CreateCheckedGeoEventCommandHandler(IGeoEventsDbContext dbContext) =>
            _dbContext = dbContext;

        //LOGIC handle command
        public async Task<Guid> Handle(CreateCheckedGeoEventCommand request,
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

            await _dbContext.CheckedGeoEvents.AddAsync(geoEvent, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return geoEvent.Id;
        }
    }
}
