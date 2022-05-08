using GeoEvents.Domain;
using GeoEvents.Persistence;
using System;
using System.Linq;

namespace HelloApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (GeoEventsDbContext db = new GeoEventsDbContext())
            {
                // создаем два объекта User
                GeoEvent user1 = new GeoEvent { Title = "Tom"};
                GeoEvent user2 = new GeoEvent { Title = "Alice"};

                // добавляем их в бд
                db.ConsideredGeoEvents.Add(user1);

                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

            }
            Console.Read();
        }
    }
}