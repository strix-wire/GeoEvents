using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MediatR;
using GeoEvents.Application.Interfaces;

namespace GeoEvents.Application.CheckedGeoEvents.Queries.GetGeoEventList
{
    public class CheckedGetGeoEventListQueryHandler
        : IRequestHandler<CheckedGetGeoEventListQuery, CheckedGeoEventListVm>
    {
        private readonly IGeoEventsDbContext _dbContext;
        private readonly IMapper _mapper;

        public CheckedGetGeoEventListQueryHandler(IGeoEventsDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CheckedGeoEventListVm> Handle(CheckedGetGeoEventListQuery request,
            CancellationToken cancellationToken)
        {
            var GeoEventsQuery = await _dbContext.CheckedGeoEvents
                //.Where(geoEvent => geoEvent.UserId == request.UserId)
                
                //Метод расширения из automapper, который проецирует коллекцию в соответствии с заданной
                //конфигурацией
                .ProjectTo<CheckedGeoEventLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CheckedGeoEventListVm { GeoEvents = GeoEventsQuery };
        }

    }
}
