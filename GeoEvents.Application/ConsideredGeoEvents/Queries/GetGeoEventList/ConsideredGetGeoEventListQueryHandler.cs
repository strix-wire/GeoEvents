using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MediatR;
using GeoEvents.Application.Interfaces;
using Geodata.Application.Interfaces;

namespace GeoEvents.Application.ConsideredGeoEvents.Queries.GetGeoEventList
{
    public class ConsideredGetGeoEventListQueryHandler
        : IRequestHandler<ConsideredGetGeoEventListQuery, ConsideredGeoEventListVm>
    {
        private readonly IGeodataDbContext _dbContext;
        private readonly IMapper _mapper;

        public ConsideredGetGeoEventListQueryHandler(IGeodataDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ConsideredGeoEventListVm> Handle(ConsideredGetGeoEventListQuery request,
            CancellationToken cancellationToken)
        {
            List<ConsideredGeoEventLookupDto> GeoEventsQuery = new();
            try
            {
                GeoEventsQuery = await _dbContext.GeodataEntities
                //.Where(geoEvent => geoEvent.UserId == request.UserId)

                //Метод расширения из automapper, который проецирует коллекцию в соответствии с заданной
                //конфигурацией
                .ProjectTo<ConsideredGeoEventLookupDto>(_mapper.ConfigurationProvider)
                .Where(x => x.IsChecked == true)
                .ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {

            }
            

            return new ConsideredGeoEventListVm { GeoEvents = GeoEventsQuery };
        }

    }
}
