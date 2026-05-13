using MiddleEarthTrader.Repository.ContextDb;
using MiddleEarthTrader.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace MiddleEarthTrader.API
{
    public static class DbSeeder
    {
        public static void SeedData(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            // Eğer veritabanı yoksa oluştur veya migrate et
            context.Database.Migrate();

            // Sadece veritabanı boşsa seed işlemi yap
            if (!context.Users.Any())
            {
                var adminUser = new User
                {
                    Username = "admin",
                    Email = "admin@middleearth.com",
                    PasswordHash = "admin123", // Test şifresi
                    Gold = 10000,
                    Role = UserRole.Admin,
                    CreatedAt = DateTime.UtcNow
                };

                var testUser = new User
                {
                    Username = "ayhan",
                    Email = "ayhan@middleearth.com",
                    PasswordHash = "123456", // Test şifresi
                    Gold = 500,
                    Role = UserRole.Player,
                    CreatedAt = DateTime.UtcNow
                };

                context.Users.AddRange(adminUser, testUser);

                var gondor = new Nation { Name = "Gondor", Type = NationType.Gondor, TradeFactor = 1.0m, CreatedAt = DateTime.UtcNow };
                var rohan = new Nation { Name = "Rohan", Type = NationType.Rohan, TradeFactor = 1.1m, CreatedAt = DateTime.UtcNow };
                var elves = new Nation { Name = "Elves", Type = NationType.Elves, TradeFactor = 1.5m, CreatedAt = DateTime.UtcNow };
                var dwarves = new Nation { Name = "Dwarves", Type = NationType.Dwarves, TradeFactor = 1.2m, CreatedAt = DateTime.UtcNow };

                context.Nations.AddRange(gondor, rohan, elves, dwarves);

                var categoryWeapons = new Category { Name = "Weapons", CreatedAt = DateTime.UtcNow };
                var categoryArmor = new Category { Name = "Armor", CreatedAt = DateTime.UtcNow };
                var categoryPotions = new Category { Name = "Potions", CreatedAt = DateTime.UtcNow };

                context.Categories.AddRange(categoryWeapons, categoryArmor, categoryPotions);

                var mat1 = new Material
                {
                    Name = "Elven Bow",
                    Description = "A masterfully crafted bow by the Elves of Lothlorien.",
                    Type = MaterialType.Weapon,
                    BasePrice = 150,
                    CurrentPrice = 150,
                    TotalStock = 50,
                    AvailableStock = 50,
                    RarityFactor = 1.5m,
                    Nation = elves,
                    CreatedAt = DateTime.UtcNow
                };

                var mat2 = new Material
                {
                    Name = "Dwarven Axe",
                    Description = "A heavy and durable axe forged in the mines of Moria.",
                    Type = MaterialType.Weapon,
                    BasePrice = 120,
                    CurrentPrice = 120,
                    TotalStock = 80,
                    AvailableStock = 80,
                    RarityFactor = 1.2m,
                    Nation = dwarves,
                    CreatedAt = DateTime.UtcNow
                };

                var mat3 = new Material
                {
                    Name = "Gondorian Shield",
                    Description = "A sturdy shield used by the guards of Minas Tirith.",
                    Type = MaterialType.Armor,
                    BasePrice = 100,
                    CurrentPrice = 100,
                    TotalStock = 100,
                    AvailableStock = 100,
                    RarityFactor = 1.0m,
                    Nation = gondor,
                    CreatedAt = DateTime.UtcNow
                };

                var mat4 = new Material
                {
                    Name = "Rohan Steed Armor",
                    Description = "Lightweight armor designed for the horses of the Rohirrim.",
                    Type = MaterialType.Armor,
                    BasePrice = 200,
                    CurrentPrice = 200,
                    TotalStock = 30,
                    AvailableStock = 30,
                    RarityFactor = 1.8m,
                    Nation = rohan,
                    CreatedAt = DateTime.UtcNow
                };

                context.Materials.AddRange(mat1, mat2, mat3, mat4);

                var event1 = new GameEvent
                {
                    Name = "Orc Invasion in Rohan",
                    Description = "Orcs are attacking the borders of Rohan. Armor prices are skyrocketing!",
                    Type = EventType.Battle,
                    ImpactLevel = EventImpactLevel.High,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddDays(7),
                    IsActive = true,
                    AlreadyHappened = false,
                    CreatedAt = DateTime.UtcNow
                };

                context.GameEvents.Add(event1);

                context.SaveChanges();
            }
        }
    }
}
