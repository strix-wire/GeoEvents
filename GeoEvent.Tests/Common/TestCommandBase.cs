using System;
using GeoEvents.Persistence;

namespace GeoEvents.Tests.Common
{
    //Класс для тестирования команд
    //В нем мы будет создавать контекст db для тестов
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly GeoEventsDbContext Context;

        public TestCommandBase()
        {
            Context = GeoEventsContextFactory.Create();
        }

        //Т.к. хотим очищать контекст после завершения работы
        public void Dispose()
        {
            GeoEventsContextFactory.Destroy(Context);
        }
    }
}
