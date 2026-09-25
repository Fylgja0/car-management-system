using CarProject_OOP.Base;
using CarProject_OOP.Enums;
using CarProject_OOP.Interface;

namespace CarProject_OOP.Concrete
{
    // Concrete class for hybrid cars
    public class HybridCar : Car, IFuel, IElectric
    {
        public float FuelCapacity { get; init; }
        public float BatteryCapacity { get; init; }

        public HybridCar(int year, string brand, CarColor carColor, string model, decimal price, float fuelCapacity, float batteryCapacity)
            :base(year, brand, carColor, model, price)
        {
            FuelCapacity = fuelCapacity;
            BatteryCapacity = batteryCapacity;
        }

        internal override double CalculateRange()
        {
            const double kmPerLiter = 15.0;
            const double kmPerkWh = 6.0;
            double fuelRange = FuelCapacity * kmPerLiter;
            double electricRange = BatteryCapacity * kmPerkWh;
            return fuelRange + electricRange;
        }
    }
}
