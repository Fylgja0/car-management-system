using CarProject_OOP.Concrete;
using CarProject_OOP.Enums;

namespace CarProject_OOP.CarLists
{
    // Class to hold a list of electric cars
    internal class ElectricCarLists
    {
        internal List<ElectricCar> electricCars = new()
        {
            new ElectricCar(2022, "Tesla", CarColor.Red, "Model S", 79999.99m, 100),
            new ElectricCar(2023, "Ford", CarColor.Blue, "Mustang Mach-E", 42999.99m, 90),
            new ElectricCar(2021, "Nissan", CarColor.Green, "Leaf", 31999.99m, 40)
        };
    }
}
