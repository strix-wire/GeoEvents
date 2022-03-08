using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MediatR;
using GeoEvents.Application.Interfaces;

namespace GeoEvents.Application.GeoEvents.Queries.GetGeoEventList
{
    public class GetGeoEventListQueryHandler
        : IRequestHandler<GetGeoEventListQuery, GeoEventListVm>
    {
        private readonly IGeoEventsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGeoEventListQueryHandler(IGeoEventsDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GeoEventListVm> Handle(GetGeoEventListQuery request,
            CancellationToken cancellationToken)
        {
            var GeoEventsQuery = await _dbContext.GeoEvents
                .Where(geoEvent => geoEvent.UserId == request.UserId)
                
                //Метод расширения из automapper, который проецирует коллекцию в соответствии с заданной
                //конфигурацией
                .ProjectTo<GeoEventLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GeoEventListVm { GeoEvents = GeoEventsQuery };
        }

    }
}
