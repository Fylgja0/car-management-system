using CarProject_OOP.Base;
using CarProject_OOP.Enums;
using CarProject_OOP.Interface;

namespace CarProject_OOP.Procedure
{
    // Class responsible for displaying the user interface and handling user interactions related to car management
    internal static class UIManager
    {
        internal static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Car Management System!");
            Console.WriteLine("Please select an option:\n");
            Console.WriteLine("1. View Gasoline Cars");
            Console.WriteLine("2. View Electric Cars");
            Console.WriteLine("3. View Hybrid Cars");
            Console.WriteLine("4. Add New Car");
            Console.WriteLine("5. Remove Car");
            Console.WriteLine("6. Update Car Price");
            Console.WriteLine("7. Exit");
            Console.Write("\nYour choice: ");
        }

        // Model & car details

        internal static void ShowCarBrands<T>(List<T> cars, string carType) where T : Car
        {
            Console.Clear();
            Console.WriteLine($"{carType} Brands:");
            Console.WriteLine(new string('=', 20));

            var brands = cars.Select(car => car.Brand).Distinct().ToList();
            for (int i = 0; i < brands.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {brands[i]}");
            }
            Console.WriteLine("0. Back to Main Menu");
        }

        internal static void ShowCarModels<T>(List<T> models) where T : Car
        {
            Console.Clear();

            if (models is null or { Count: 0 })
            {
                Console.WriteLine("No models found.");
                Console.WriteLine("0. Back to Main Menu");
                return;
            }

            Console.WriteLine($"{models[0].Brand} - Models");
            Console.WriteLine(new string('=', 20));

            for (int i = 0; i < models.Count; i++)
            {
                var car = models[i];
                Console.WriteLine($"{i + 1}. {car.Model} ({car.Year}) - Price: ${car.Price}");
            }
            Console.WriteLine("0. Back to Brand Selection");
        }

        internal static void ShowCarDetails(Car car)
        {
            Console.Clear();
            Console.WriteLine("Car Details:");
            Console.WriteLine(new string('=', 20));
            Console.WriteLine(car.ToString());

            if (car is IFuel fuelCar)
            {
                Console.WriteLine($"Fuel Capacity: {fuelCar.FuelCapacity} L");
            }

            if (car is IElectric electricCar)
            {
                Console.WriteLine($"Battery Capacity: {electricCar.BatteryCapacity} kWh");
            }

            Console.WriteLine($"Estimated Range: {car.CalculateRange():F1} km");

            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }

        // Menu helpers & utilities

        internal static void ShowCarTypeSelectionMenu(string actionType)
        {
            Console.Clear();
            Console.WriteLine($"Select a car type to {actionType}:");
            Console.WriteLine(new string('=', 20));
            Console.WriteLine("1. Gasoline Car");
            Console.WriteLine("2. Electric Car");
            Console.WriteLine("3. Hybrid Car");
            Console.WriteLine("0. Back to Main Menu");
            Console.Write("\nEnter your choice: ");
        }

        internal static void ShowSuccessMessage(string carType, string action)
        {
            Console.WriteLine($"\n{carType} {action} successfully!");
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }

        internal static void ShowInvalidChoiceMessage()
        {
            Console.WriteLine("\nInvalid choice! Please try again.");
            Thread.Sleep(1200);
        }

        // Input validation helper methods

        internal static string ReadString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input;
                ShowInvalidChoiceMessage();
            }
        }

        internal static int ReadInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                    return value;
                ShowInvalidChoiceMessage();
            }
        }

        internal static decimal ReadPositiveDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal value) && value > 0)
                    return value;
                ShowInvalidChoiceMessage();
            }
        }

        internal static float ReadPositiveFloat(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (float.TryParse(Console.ReadLine(), out float value) && value > 0)
                    return value;
                ShowInvalidChoiceMessage();
            }
        }

        internal static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, Enum
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (!int.TryParse(input, out _) && Enum.TryParse<TEnum>(input, true, out var result) && Enum.IsDefined(result))
                    return result;
                ShowInvalidChoiceMessage();
            }
        }

        internal static (string brand, string model, int year, decimal price, CarColor color) ReadBaseCarDetails()
        {
            string brand = ReadString("Brand: ");
            string model = ReadString("Model: ");
            int year = ReadInt("Year: ", 1886, DateTime.Now.Year + 1);
            decimal price = ReadPositiveDecimal("Price: ");
            CarColor color = ReadEnum<CarColor>("Color: ");

            return (brand, model, year, price, color);
        }

        internal static int GetUserSelection(int maxOptions, string selectionType)
        {
            while (true)
            {
                Console.Write($"Please select a {selectionType} number: ");
                string? input = Console.ReadLine();

                if (input == "0")
                {
                    return -1; // Indicates user wants to go back
                }

                if (int.TryParse(input, out int selection) && selection > 0 && selection <= maxOptions)
                {
                    return selection - 1; // Convert to zero-based index
                }

                ShowInvalidChoiceMessage();
            }
        }
    }
}
