using AutoMapper;
using System;
using GeoEvents.Application.Interfaces;
using GeoEvents.Application.Common.Mappings;
using GeoEvents.Persistence;
using Xunit;

namespace GeoEvents.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public GeoEventsDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = GeoEventsContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IGeoEventsDbContext).Assembly));
            });
            //Создадим маппер
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            GeoEventsContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
