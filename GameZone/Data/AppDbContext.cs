
using GameZone.Models;

namespace GameZone.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GameCategory> GameCategories { get; set; }
        public DbSet<GameDevice> GameDevices { get; set; }
        public DbSet<Device> Devices { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
            .HasData(
            [
                new Category { Id = 1, Name = "RPG" },
                new Category { Id = 2, Name = "Stealth" },
                new Category { Id = 3, Name = "Adventure" },
                new Category { Id = 4, Name = "Action" },
                new Category { Id = 5, Name = "FPS" },
                new Category { Id = 6, Name = "Fighting" }
            ]);

            modelBuilder.Entity<Device>()
                .HasData(new Device[]
                {
                new Device { Id = 1, Name = "PlayStation", Icon = "bi bi-playstation" },
                new Device { Id = 2, Name = "xbox", Icon = "bi bi-xbox" },
                new Device { Id = 3, Name = "Nintendo Switch", Icon = "bi bi-nintendo-switch" },
                new Device { Id = 4, Name = "PC", Icon = "bi bi-pc-display" }
                });

            modelBuilder.Entity<GameCategory>().HasKey(e => new { e.CategoryId, e.GameId });
            modelBuilder.Entity<GameDevice>().HasKey(e => new { e.DeviceId, e.GameId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
