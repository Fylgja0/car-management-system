using CarProject_OOP.Base;
using CarProject_OOP.Enums;
using CarProject_OOP.Interface;

namespace CarProject_OOP.Concrete
{
    // Concrete class for electric cars
    internal class ElectricCar : Car, IElectric
    {
        public float BatteryCapacity { get; init; }

        public ElectricCar(int year, string brand, CarColor carColor, string model, decimal price, float batteryCapacity)
            :base(year, brand, carColor, model, price)
        {
            BatteryCapacity = batteryCapacity;
        }

        internal override double CalculateRange()
        {
            const double kmPerkWh = 6.0;
            return BatteryCapacity * kmPerkWh;
        }
    }
}
