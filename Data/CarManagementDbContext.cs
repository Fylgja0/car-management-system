using CarProject_OOP.Base;
using CarProject_OOP.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CarProject_OOP.Data;

public class CarManagementDbContext : DbContext
{
    public DbSet<Car> Cars => Set<Car>();
    public DbSet<GasolineCar> GasolineCars => Set<GasolineCar>();
    public DbSet<ElectricCar> ElectricCars => Set<ElectricCar>();
    public DbSet<HybridCar> HybridCars => Set<HybridCar>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Environment.GetEnvironmentVariable("CAR_MANAGEMENT_DB_CONNECTION");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("CAR_MANAGEMENT_DB_CONNECTION environment variable is not set.");
        }

        optionsBuilder.UseSqlServer(connectionString);
    }
}
