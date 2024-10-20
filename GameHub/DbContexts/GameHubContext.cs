using GameHub.Entities;
using Microsoft.EntityFrameworkCore;


namespace GameHub.DbContexts
{
    public class GameHubContext(DbContextOptions<GameHubContext> options) : DbContext(options)
    {
        public DbSet<Game> Games { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the data base with dummy data
            modelBuilder.Entity<Game>().HasData(
                 new Game() {
                     ID = 1,
                     Title = "The Elder Scrolls V: Skyrim",
                     Genre = "Role-playing",
                     Description = "Open world action role-playing video game.",
                     StockQuantity = 120,
                     Price = 39.99,
                     ReleaseDate = new DateTimeOffset(new DateTime(2011, 11, 1))
                 },
                new Game() { 
                    ID = 2,
                    Title = "The Witcher 3: Wild Hunt",
                    Genre = "Action",
                    Description = "Action role-playing game set in a lush, open world.",
                    StockQuantity = 150,
                    Price = 49.99,
                    ReleaseDate = new DateTimeOffset(new DateTime(2015, 5, 18))
                },
                new Game()
                {
                    ID = 3,
                    Title = "Cyberpunk 2077",
                    Genre = "Action",
                    Description = "Open-world, action-adventure story set in Night City.",
                    StockQuantity = 80,
                    Price = 59.99,
                    ReleaseDate = new DateTimeOffset(new DateTime(2020, 12, 10))
                },
                new Game()
                {
                    ID = 4,
                    Title = "Minecraft",
                    Genre = "Sandbox",
                    Description = "Sandbox game that allows players to build with a variety of different blocks in a 3D procedurally generated world.",
                    StockQuantity = 0,
                    Price = 26.95,
                    ReleaseDate = new DateTimeOffset(new DateTime(2011, 11, 18))
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
