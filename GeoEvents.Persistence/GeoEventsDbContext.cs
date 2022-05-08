using GeoEvents.Application.Interfaces;
using GeoEvents.Domain;
using GeoEvents.Persistence.EntityTypeConfigurations;
using GeoEvents.Persistence.IdentityEF;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeoEvents.Persistence
{
    public class GeoEventsDbContext : IdentityDbContext<MyIdentityUser>, IGeoEventsDbContext
    {
        public DbSet<GeoEventConsidered> ConsideredGeoEvents { get; set; }
        public DbSet<GeoEventChecked> CheckedGeoEvents { get; set; }

        public GeoEventsDbContext(DbContextOptions<GeoEventsDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GeoEventConfiguration());
            base.OnModelCreating(builder);

            string idRoleAdmin = Guid.NewGuid().ToString();
            string idRoleUser = Guid.NewGuid().ToString();
            string idRoleModerator = Guid.NewGuid().ToString();
            string idAccoundAdmin = Guid.NewGuid().ToString();

            //Создание ролей
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = idRoleAdmin,
                NormalizedName = "ADMIN",
                Name = "Admin",
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = idRoleUser,
                NormalizedName = "USER",
                Name = "User",
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = idRoleModerator,
                NormalizedName = "MODERATOR",
                Name = "Moderator",
            });

            //Создание админа
            var hasher = new PasswordHasher<MyIdentityUser>();
            builder.Entity<MyIdentityUser>().HasData(new MyIdentityUser
            {
                Id = idAccoundAdmin,
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                Name = "Admin",
                Email = "admin@gmail.com",
                Surname = "AdminSurname",
                MiddleName = "AdminMiddleName",
                //DateOfBirth = model.DateOfBirth,
                City = "Tomsk",
                PasswordHash = hasher.HashPassword(null, "5tgmL1.2Ls"),
                //Sex = model.Sex
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = idRoleAdmin,
                UserId = idAccoundAdmin
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = idRoleUser,
                UserId = idAccoundAdmin
            });
        }
    }
}
