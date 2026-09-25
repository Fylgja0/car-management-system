using CarProject_OOP.Base;
using CarProject_OOP.Concrete;
using CarProject_OOP.Enums;

namespace CarProject_OOP.Data
{
    // Manages a collection of cars, providing methods for adding, removing, and retrieving cars.
    internal class CarCollection
    {
        private readonly CarManagementDbContext _context;

        public CarCollection()
        {
            _context = new CarManagementDbContext();

            if (!_context.Cars.Any())
            {
                SeedInitialData();
            }
        }

        internal List<T> GetCars<T>() where T : Car
        {
            return _context.Set<T>().ToList();
        }

        internal void AddCar(Car car)
        {
            _context.Set<Car>().Add(car);
            _context.SaveChanges();
        }

        internal bool RemoveCar(Car car)
        {
            _context.Set<Car>().Remove(car);
            return _context.SaveChanges() > 0;
        }

        internal void UpdateCarPrice(Car car, decimal newPrice)
        {
            car.UpdatePrice(newPrice);
            _context.SaveChanges();
        }

        private void SeedInitialData()
        {
            var cars = new List<Car>
            {
                // Gasoline Cars
                new GasolineCar(2021, "Honda", CarColor.Gray, "Civic", 22999.99m, 50),
                new GasolineCar(2020, "Toyota", CarColor.Green, "Corolla", 19999.99m, 45),
                new GasolineCar(2022, "Ford", CarColor.Black, "Mustang", 35999.99m, 60),

                // Electric Cars
                new ElectricCar(2022, "Tesla", CarColor.Red, "Model S", 79999.99m, 100),
                new ElectricCar(2023, "Ford", CarColor.Blue, "Mustang Mach-E", 42999.99m, 90),
                new ElectricCar(2021, "Nissan", CarColor.Green, "Leaf", 31999.99m, 40),

                // Hybrid Cars
                new HybridCar(2023, "Toyota", CarColor.Green, "Prius", 29999.99m, 50, 40),
                new HybridCar(2022, "Honda", CarColor.Gray, "Accord Hybrid", 27999.99m, 45, 35),
                new HybridCar(2021, "Ford", CarColor.Black, "Escape Hybrid", 31999.99m, 60, 45)
            };

            _context.AddRange(cars);
            _context.SaveChanges();
        }
    }
}
