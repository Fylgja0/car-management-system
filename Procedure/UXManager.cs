using CarProject_OOP.Base;
using CarProject_OOP.Data;
using CarProject_OOP.Concrete;
using CarProject_OOP.Enums;

namespace CarProject_OOP.Procedure
{
    // Class responsible for managing the user experience, including displaying menus and handling user input
    internal class UXManager
    {
        private readonly CarCollection _carCollection;

        public UXManager()
        {
            _carCollection = new();
        }

        internal void Run()
        {
            bool exit = false;
            while (!exit)
            {
                UIManager.DisplayMenu();
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowCarMenu<GasolineCar>("Gasoline Car");
                        break;

                    case "2":
                        ShowCarMenu<ElectricCar>("Electric Car");
                        break;

                    case "3":
                        ShowCarMenu<HybridCar>("Hybrid Car");
                        break;

                    case "4":
                        ExecuteCarTypeAction("add", AddGasolineCar, AddElectricCar, AddHybridCar);
                        break;

                    case "5":
                        ExecuteCarTypeAction("remove",
                            () => RemoveCar<GasolineCar>("Gasoline Car"),
                            () => RemoveCar<ElectricCar>("Electric Car"),
                            () => RemoveCar<HybridCar>("Hybrid Car"));
                        break;

                    case "6":
                        ExecuteCarTypeAction("update price for",
                            () => UpdateCarPrice<GasolineCar>("Gasoline Car"),
                            () => UpdateCarPrice<ElectricCar>("Electric Car"),
                            () => UpdateCarPrice<HybridCar>("Hybrid Car"));
                        break;

                    case "7":
                        exit = true;
                        Console.WriteLine("Thank you for using the Car Management System. Goodbye!");
                        Thread.Sleep(1500);
                        break;

                    default:
                        UIManager.ShowInvalidChoiceMessage();
                        break;
                }
            }
        }

        // Menu router

        private static void ExecuteCarTypeAction(string actionType, Action gasolineAction, Action electricAction, Action hybridAction)
        {
            UIManager.ShowCarTypeSelectionMenu(actionType);
            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1": gasolineAction(); break;
                case "2": electricAction(); break;
                case "3": hybridAction(); break;
                case "0": break;
                default: UIManager.ShowInvalidChoiceMessage(); break;
            }
        }

        // Selection & core actions

        private void ShowCarMenu<T>(string carType) where T : Car
        {
            var cars = _carCollection.GetCars<T>();
            var selectedCar = SelectCar(cars, $"Select {carType}");
            if (selectedCar is not null)
            {
                UIManager.ShowCarDetails(selectedCar);
            }
        }

        private static T? SelectCar<T>(List<T> cars, string actionType) where T : Car
        {
            if (cars is null or { Count: 0 })
            {
                Console.WriteLine($"=== {actionType} ===");
                Console.WriteLine("No cars available.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return null;
            }

            UIManager.ShowCarBrands(cars, actionType);
            var brands = cars.Select(car => car.Brand).Distinct().ToList();

            int brandIndex = UIManager.GetUserSelection(brands.Count, "brand");
            if (brandIndex == -1) return null;

            string selectedBrand = brands[brandIndex];
            var models = cars.Where(car => car.Brand == selectedBrand).ToList();

            UIManager.ShowCarModels(models);
            int modelIndex = UIManager.GetUserSelection(models.Count, "model");
            if (modelIndex == -1) return null;

            return models[modelIndex];
        }

        private void RemoveCar<T>(string carType) where T : Car
        {
            var cars = _carCollection.GetCars<T>();
            var carToRemove = SelectCar(cars, $"Remove {carType}");
            if (carToRemove is null) return;

            _carCollection.RemoveCar(carToRemove);

            UIManager.ShowSuccessMessage(carType, "removed");
        }

        private void UpdateCarPrice<T>(string carType) where T : Car
        {
            var cars = _carCollection.GetCars<T>();
            var carToUpdate = SelectCar(cars, $"Update {carType} Price");
            if (carToUpdate is null) return;

            decimal newPrice = UIManager.ReadPositiveDecimal($"Enter new price for {carToUpdate.Brand} {carToUpdate.Model}: $");
            carToUpdate.UpdatePrice(newPrice);

            UIManager.ShowSuccessMessage(carType, "price updated");
        }

        // Add car actions

        private void AddCar<T>(string headerTitle, string carType, Func<(string brand, string model, int year, decimal price, CarColor color), T> createCar) where T : Car
        {
            Console.WriteLine($"\n=== {headerTitle} ===");
            var baseDetails = UIManager.ReadBaseCarDetails();

            T newCar = createCar(baseDetails);
            _carCollection.AddCar(newCar);

            UIManager.ShowSuccessMessage(carType, "added");
        }

        private void AddGasolineCar() =>
            AddCar("Add New Gasoline Car", "Gasoline Car",
                b => new GasolineCar(b.year, b.brand, b.color, b.model, b.price, UIManager.ReadPositiveFloat("Fuel Capacity (L): ")));

        private void AddElectricCar() =>
            AddCar("Add New Electric Car", "Electric Car",
                b => new ElectricCar(b.year, b.brand, b.color, b.model, b.price, UIManager.ReadPositiveFloat("Battery Capacity (kWh): ")));

        private void AddHybridCar() =>
            AddCar("Add New Hybrid Car", "Hybrid Car",
                b => new HybridCar(b.year, b.brand, b.color, b.model, b.price, UIManager.ReadPositiveFloat("Fuel Capacity (L): "), UIManager.ReadPositiveFloat("Battery Capacity (kWh): ")));
    }
}
