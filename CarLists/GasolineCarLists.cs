using CarProject_OOP.Concrete;
using CarProject_OOP.Enums;

namespace CarProject_OOP.CarLists
{
    // Class to hold a list of gasoline cars
    internal class GasolineCarLists
    {
        internal List<GasolineCar> gasolineCars = new()
        {
            new GasolineCar(2021, "Honda", CarColor.Gray, "Civic", 22999.99m, 50),
            new GasolineCar(2020, "Toyota", CarColor.Green, "Corolla", 19999.99m, 45),
            new GasolineCar(2022, "Ford", CarColor.Black, "Mustang", 35999.99m, 60)
        };
    }
}
