using CarProject_OOP.Enums;

namespace CarProject_OOP.Base
{
    // Base class for all car types
    internal abstract class Car
    {
        public int Year { get; init; }
        public string Model { get; init; }
        public CarColor CarColor { get; init; }
        public string Brand { get; init; }
        public decimal Price { get; private set; }

        protected Car(int year, string brand, CarColor carColor, string model, decimal price)
        {
            Year = year;
            Brand = brand;
            CarColor = carColor;
            Model = model;
            Price = price;
        }

        internal void UpdatePrice(decimal newPrice)
        {
            Price = newPrice;
        }

        internal abstract double CalculateRange();

        public override string ToString()
        {
            return $"Year: {Year}, Model: {Model}, Color: {CarColor}, Brand: {Brand}, Price: ${Price}";
        }
    }
}
