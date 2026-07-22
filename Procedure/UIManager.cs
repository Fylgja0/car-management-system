using CarProject_OOP.Base;
using CarProject_OOP.Concrete;
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

        internal static void ShowGasolineBrands(List<GasolineCar> gasolineCars)
        {
            Console.Clear();
            Console.WriteLine("Gasoline Car Brands:");
            Console.WriteLine(new string('=', 20));

            var brands = gasolineCars.Select(car => car.Brand).Distinct().ToList();
            for (int i = 0; i < brands.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {brands[i]}");
            }
            Console.WriteLine("0. Back to Main Menu");
        }

        internal static void ShowGasolineModels(List<GasolineCar> models)
        {
            Console.Clear();
            Console.WriteLine($"{models[0].Brand} - Models:");
            Console.WriteLine(new string('=', 20));

            for (int i = 0; i < models.Count; i++)
            {
                var car = models[i];
                Console.WriteLine($"{i + 1}. {car.Model} ({car.Year})");
            }
            Console.WriteLine("0. Back to Brand Selection");
        }

        internal static void ShowElectricBrands(List<ElectricCar> electricCars)
        {
            Console.Clear();
            Console.WriteLine("Electric Car Brands:");
            Console.WriteLine(new string('=', 20));

            var brands = electricCars.Select(car => car.Brand).Distinct().ToList();
            for (int i = 0; i < brands.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {brands[i]}");
            }
            Console.WriteLine("0. Back to Main Menu");
        }

        internal static void ShowElectricModels(List<ElectricCar> models)
        {
            Console.Clear();
            Console.WriteLine($"{models[0].Brand} - Models");
            Console.WriteLine(new string('=', 20));

            for (int i = 0; i < models.Count; i++)
            {
                var car = models[i];
                Console.WriteLine($"{i + 1}. {car.Model} ({car.Year})");
            }
            Console.WriteLine("0. Back to Brand Selection");
        }

        internal static void ShowHybridBrands(List<HybridCar> hybridCars)
        {
            Console.Clear();
            Console.WriteLine("Hybrid Car Brands:");
            Console.WriteLine(new string('=', 20));

            var brands = hybridCars.Select(car => car.Brand).Distinct().ToList();
            for (int i = 0; i < brands.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {brands[i]}");
            }
            Console.WriteLine("0. Back to Main Menu");
        }

        internal static void ShowHybridModels(List<HybridCar> models)
        {
            Console.Clear();
            Console.WriteLine($"{models[0].Brand} - Models");
            Console.WriteLine(new string('=', 20));

            for (int i = 0; i < models.Count; i++)
            {
                var car = models[i];
                Console.WriteLine($"{i + 1}. {car.Model} ({car.Year})");
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

        // Displays the menu for adding a new car and prompts the user to select the type of car they want to add
        internal static void ShowAddCarMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Add New Car ===");
            Console.WriteLine("Select Car Type:\n");
            Console.WriteLine("1. Add Gasoline Car");
            Console.WriteLine("2. Add Electric Car");
            Console.WriteLine("3. Add Hybrid Car");
            Console.WriteLine("0. Back to Main Menu");
            Console.Write("\nYour choice: ");
        }

        internal static void ShowAddedCarSuccessMessage(string carType)
        {
            Console.WriteLine($"\n{carType} added successfully!");
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }

        // Displays the menu for removing a car and prompts the user to select the type of car they want to remove
        internal static void ShowRemoveCarMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Remove Car ===");
            Console.WriteLine("Select Car Type to Remove:\n");
            Console.WriteLine("1. Remove Gasoline Car");
            Console.WriteLine("2. Remove Electric Car");
            Console.WriteLine("3. Remove Hybrid Car");
            Console.WriteLine("0. Back to Main Menu");
            Console.Write("\nYour choice: ");
        }

        internal static void ShowRemovedCarSuccessMessage(string carType)
        {
            Console.WriteLine($"\n{carType} removed successfully!");
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }

        // Displays the menu for updating a car's price and prompts the user to select the type of car they want to update
        internal static void ShowUpdatePriceMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Update Car Price ===");
            Console.WriteLine("Select Car Type to Update:\n");
            Console.WriteLine("1. Update Gasoline Car Price");
            Console.WriteLine("2. Update Electric Car Price");
            Console.WriteLine("3. Update Hybrid Car Price");
            Console.WriteLine("0. Back to Main Menu");
            Console.Write("\nYour choice: ");
        }

        internal static void ShowUpdatedPriceSuccessMessage(string carType)
        {
            Console.WriteLine($"\n{carType} price updated successfully!");
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }

        internal static void ShowInvalidChoiceMessage()
        {
            Console.WriteLine("Invalid choice! Please try again.");
            Thread.Sleep(1500);
        }
    }
}
