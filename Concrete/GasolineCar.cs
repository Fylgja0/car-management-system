using CarProject_OOP.Base;
using CarProject_OOP.Enums;
using CarProject_OOP.Interface;

namespace CarProject_OOP.Concrete
{
    // Concrete class for gasoline cars
    public class GasolineCar : Car, IFuel
    {
        public float FuelCapacity { get; init; }

        public GasolineCar(int year, string brand, CarColor carColor, string model, decimal price, float fuelCapacity)
            :base(year, brand, carColor, model, price)
        {
            FuelCapacity = fuelCapacity;
        }

        internal override double CalculateRange()
        {
            const double kmPerLiter = 15.0;
            return FuelCapacity * kmPerLiter;
        }
    }
}
