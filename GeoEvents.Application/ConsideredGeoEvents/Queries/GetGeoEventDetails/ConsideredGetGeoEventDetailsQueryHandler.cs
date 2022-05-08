using GeoEvents.Application.Interfaces;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using GeoEvents.Application.Common.Exceptions;
using GeoEvents.Domain;

namespace GeoEvents.Application.ConsideredGeoEvents.Queries.GetGeoEventDetails
{
    public class ConsideredGetGeoEventDetailsQueryHandler
        : IRequestHandler<ConsideredGetGeoEventDetailsQuery, ConsideredGeoEventDetailsVm>
    {
        private readonly IGeoEventsDbContext _dbContext;
        private readonly IMapper _mapper;

        public ConsideredGetGeoEventDetailsQueryHandler(IGeoEventsDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<ConsideredGeoEventDetailsVm> Handle(ConsideredGetGeoEventDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.ConsideredGeoEvents
                .FirstOrDefaultAsync(geoEvent =>
                geoEvent.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(GeoEventConsidered), request.Id);
            }

            return _mapper.Map<ConsideredGeoEventDetailsVm>(entity);
        }
    }
}
