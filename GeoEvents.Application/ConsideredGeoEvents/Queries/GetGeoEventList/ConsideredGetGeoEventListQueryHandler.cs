using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MediatR;
using GeoEvents.Application.Interfaces;

namespace GeoEvents.Application.ConsideredGeoEvents.Queries.GetGeoEventList
{
    public class ConsideredGetGeoEventListQueryHandler
        : IRequestHandler<ConsideredGetGeoEventListQuery, ConsideredGeoEventListVm>
    {
        private readonly IGeoEventsDbContext _dbContext;
        private readonly IMapper _mapper;

        public ConsideredGetGeoEventListQueryHandler(IGeoEventsDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ConsideredGeoEventListVm> Handle(ConsideredGetGeoEventListQuery request,
            CancellationToken cancellationToken)
        {
            var GeoEventsQuery = await _dbContext.ConsideredGeoEvents
                //.Where(geoEvent => geoEvent.UserId == request.UserId)
                
                //Метод расширения из automapper, который проецирует коллекцию в соответствии с заданной
                //конфигурацией
                .ProjectTo<ConsideredGeoEventLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ConsideredGeoEventListVm { GeoEvents = GeoEventsQuery };
        }

    }
}
