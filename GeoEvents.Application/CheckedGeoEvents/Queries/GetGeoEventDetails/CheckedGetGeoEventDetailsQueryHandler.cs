using GeoEvents.Application.Interfaces;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using GeoEvents.Application.Common.Exceptions;
using GeoEvents.Domain;

namespace GeoEvents.Application.CheckedGeoEvents.Queries.GetGeoEventDetails
{
    public class CheckedGetGeoEventDetailsQueryHandler
        : IRequestHandler<CheckedGetGeoEventDetailsQuery, CheckedGeoEventDetailsVm>
    {
        private readonly IGeoEventsDbContext _dbContext;
        private readonly IMapper _mapper;

        public CheckedGetGeoEventDetailsQueryHandler(IGeoEventsDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<CheckedGeoEventDetailsVm> Handle(CheckedGetGeoEventDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.CheckedGeoEvents
                .FirstOrDefaultAsync(geoEvent =>
                geoEvent.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(GeoEventChecked), request.Id);
            }

            return _mapper.Map<CheckedGeoEventDetailsVm>(entity);
        }
    }
}
