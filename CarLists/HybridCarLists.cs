using CarProject_OOP.Concrete;
using CarProject_OOP.Enums;

namespace CarProject_OOP.CarLists
{
    // Class to hold a list of hybrid cars
    internal class HybridCarLists
    {
        internal List<HybridCar> hybridCars = new()
        {
            new HybridCar(2023, "Toyota", CarColor.Green, "Prius", 29999.99m, 50, 40),
            new HybridCar(2022, "Honda", CarColor.Gray, "Accord Hybrid", 27999.99m, 45, 35),
            new HybridCar(2021, "Ford", CarColor.Black, "Escape Hybrid", 31999.99m, 60, 45)
        };
    }
}
