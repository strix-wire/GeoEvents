using System;
using Microsoft.EntityFrameworkCore;
using GeoEvents.Domain;
using GeoEvents.Persistence;

namespace GeoEvents.Tests.Common
{
    //Т.к. тесты не должны зависеть от бд приложения
    //Следовательно создадим тестовые данные соответствующие DbContext приложения
    public class GeoEventsContextFactory
    {
        //UserA and UserB
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid GeoEventIdForDelete = Guid.NewGuid();
        public static Guid GeoEventIdForUpdate = Guid.NewGuid();

        public static GeoEventsDbContext Create()
        {
            var options = new DbContextOptionsBuilder<GeoEventsDbContext>()
                //будем использовать in memory DB, 
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            //получаем контекст options и с его помощью создаем GeoEventsDbContext
            var context = new GeoEventsDbContext(options);
            //убедимся, что база создана
            context.Database.EnsureCreated();
            //заполняем бд тестовыми данными
            context.ConsideredGeoEvents.AddRange(
                new GeoEventConsidered
                {
                    CreationDate = DateTime.Today,
                    Details = "Details1",
                    EditDate = null,
                    //чтобы id не менялся и его можно было изменять
                    Id = Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825"),
                    Title = "Title1",
                    UserId = UserAId
                },
                new GeoEventConsidered
                {
                    CreationDate = DateTime.Today,
                    Details = "Details2",
                    EditDate = null,
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"),
                    Title = "Title2",
                    UserId = UserBId
                },
                new GeoEventConsidered
                {
                    CreationDate = DateTime.Today,
                    Details = "Details3",
                    EditDate = null,
                    Id = GeoEventIdForDelete,
                    Title = "Title3",
                    UserId = UserAId
                },
                new GeoEventConsidered
                {
                    CreationDate = DateTime.Today,
                    Details = "Details4",
                    EditDate = null,
                    Id = GeoEventIdForUpdate,
                    Title = "Title4",
                    UserId = UserBId
                }
            );
            context.SaveChanges();
            return context;
        }

        //Убеждаемся, что база удалена
        public static void Destroy(GeoEventsDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
