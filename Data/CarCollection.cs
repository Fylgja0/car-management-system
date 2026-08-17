using CarProject_OOP.Base;
using CarProject_OOP.Concrete;
using CarProject_OOP.Enums;

namespace CarProject_OOP.Data
{
    // Manages a collection of cars, providing methods for adding, removing, and retrieving cars.
    internal class CarCollection
    {
        private readonly List<Car> _cars;

        public CarCollection()
        {
            _cars = SeedInitialData();
        }

        internal List<T> GetCars<T>() where T : Car
        {
            return _cars.OfType<T>().ToList();
        }

        internal void AddCar(Car car) => _cars.Add(car);

        internal bool RemoveCar(Car car) => _cars.Remove(car);

        private static List<Car> SeedInitialData()
        {
            return new List<Car>
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
        }
    }
}
