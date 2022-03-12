using MediatR;
using GeoEvents.Domain;
using GeoEvents.Application.Interfaces;

namespace GeoEvents.Application.GeoEvents.Commands.CreateGeoEvent
{
    //CreateGeoEventCommand - type queries, Guid - type response
    public class CreateGeoEventCommandHandler : IRequestHandler<CreateGeoEventCommand, Guid>
    {
        private readonly IGeoEventsDbContext _dbContext;

        public CreateGeoEventCommandHandler(IGeoEventsDbContext dbContext) =>
            _dbContext = dbContext;

        //LOGIC handle command
        public async Task<Guid> Handle(CreateGeoEventCommand request,
            CancellationToken cancellationToken)
        {
            var geoEvent = new GeoEvent
            {
                UserId = request.UserId,
                Id = Guid.NewGuid(),
                Title = request.Title,
                Details = request.Details,

                CreationDate = DateTime.Now,
                EditDate = null
            };

            await _dbContext.GeoEvents.AddAsync(geoEvent, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return geoEvent.Id;
        }
    }
}
