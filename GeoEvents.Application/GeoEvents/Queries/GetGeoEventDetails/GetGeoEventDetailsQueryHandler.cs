using GeoEvents.Application.Interfaces;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using GeoEvents.Application.Common.Exceptions;
using GeoEvents.Domain;

namespace GeoEvents.Application.GeoEvents.Queries.GetGeoEventDetails
{
    public class GetGeoEventDetailsQueryHandler
        : IRequestHandler<GetGeoEventDetailsQuery, GeoEventDetailsVm>
    {
        private readonly IGeoEventsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGeoEventDetailsQueryHandler(IGeoEventsDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<GeoEventDetailsVm> Handle(GetGeoEventDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.GeoEvents
                .FirstOrDefaultAsync(geoEvent =>
                geoEvent.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(GeoEvent), request.Id);
            }

            return _mapper.Map<GeoEventDetailsVm>(entity);
        }
    }
}
