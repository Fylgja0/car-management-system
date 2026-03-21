using CarProject_OOP.CarLists;
using CarProject_OOP.Enums;
using CarProject_OOP.Concrete;

namespace CarProject_OOP.Procedure
{
    // Class responsible for managing the user experience, including displaying menus and handling user input
    internal class UXManager
    {
        private readonly UIManager _uiManager;
        private readonly GasolineCarLists _gasolineCarLists;
        private readonly ElectricCarLists _electricCarLists;
        private readonly HybridCarLists _hybridCarLists;

        public UXManager()
        {
            _uiManager = new();
            _gasolineCarLists = new();
            _electricCarLists = new();
            _hybridCarLists = new();
        }

        internal void Run()
        {
            bool exit = false;
            while (!exit)
            {
                _uiManager.DisplayMenu();
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        GasolinCarMenu();
                        break;

                    case "2":
                        ElectricCarMenu();
                        break;

                    case "3":
                        HybridCarMenu();
                        break;

                    case "4":
                        AddNewCarMenu();
                        break;

                    case "5":
                        RemoveCarMenu();
                        break;

                    case "6":
                        UpdateCarPriceMenu();
                        break;

                    case "7":
                        exit = true;
                        Console.Write("Thank you for using the Car Management System. Goodbye!");
                        Thread.Sleep(2000); // Pause for 2 seconds before closing
                        break;

                    default:
                        _uiManager.ShowInvalidChoiceMessage();
                        break;
                }
            }
        }

        private void GasolinCarMenu()
        {
            // Show list of gasoline car brands
            _uiManager.ShowGasolineBrands(_gasolineCarLists.gasolineCars);

            // Get user selection for brand
            int brandIndex = GetUserSelection(_gasolineCarLists.gasolineCars.Count, "brand");
            if (brandIndex == -1) return; // User chose to go back

            var selectBrandCars = _gasolineCarLists.gasolineCars
                .Where(car => car.Brand == _gasolineCarLists.gasolineCars[brandIndex].Brand)
                .ToList();

            // Show models of the selected brand
            _uiManager.ShowGasolineModels(selectBrandCars);

            // Get user selection for model
            int modelIndex = GetUserSelection(selectBrandCars.Count, "model");
            if (modelIndex == -1) return; // User chose to go back

            // Show details of the selected car
            var selectedCar = selectBrandCars[modelIndex];
            _uiManager.ShowCarDetails(selectedCar);
        }

        private void ElectricCarMenu()
        {
            // Show list of electric car brands
            _uiManager.ShowElectricBrands(_electricCarLists.electricCars);

            // Get user selection for brand
            int brandIndex = GetUserSelection(_electricCarLists.electricCars.Count, "brand");
            if (brandIndex == -1) return; // User chose to go back

            var selectBrandCars = _electricCarLists.electricCars
                .Where(car => car.Brand == _electricCarLists.electricCars[brandIndex].Brand)
                .ToList();

            // Show models of the selected brand
            _uiManager.ShowElectricModels(selectBrandCars);

            // Get user selection for model
            int modelIndex = GetUserSelection(selectBrandCars.Count, "model");
            if (modelIndex == -1) return; // User chose to go back

            // Show details of the selected car
            var selectedCar = selectBrandCars[modelIndex];
            _uiManager.ShowCarDetails(selectedCar);
        }

        private void HybridCarMenu()
        {
            // Show list of hybrid car brands
            _uiManager.ShowHybridBrands(_hybridCarLists.hybridCars);

            // Get user selection for brand
            int brandIndex = GetUserSelection(_hybridCarLists.hybridCars.Count, "brand");
            if (brandIndex == -1) return; // User chose to go back

            var selectBrandCars = _hybridCarLists.hybridCars
                .Where(car => car.Brand == _hybridCarLists.hybridCars[brandIndex].Brand)
                .ToList();

            // Show models of the selected brand
            _uiManager.ShowHybridModels(selectBrandCars);

            // Get user selection for model
            int modelIndex = GetUserSelection(selectBrandCars.Count, "model");
            if (modelIndex == -1) return; // User chose to go back

            // Show details of the selected car
            var selectedCar = selectBrandCars[modelIndex];
            _uiManager.ShowCarDetails(selectedCar);
        }

        private void AddNewCarMenu()
        {
            _uiManager.ShowAddCarMenu();
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddGasolineCar();
                    break;

                case "2":
                    AddElectricCar();
                    break;

                case "3":
                    AddHybridCar();
                    break;

                case "0":
                    return; // Go back to main menu

                default:
                    _uiManager.ShowInvalidChoiceMessage();
                    break;
            }
        }

        private void AddGasolineCar()
        {
            Console.Clear();
            Console.WriteLine("=== Add New Gasoline Car ===\n");

            Console.Write("Brand: ");
            string? brand = Console.ReadLine();

            Console.Write("Model: ");
            string? model = Console.ReadLine();

            Console.Write("Year: ");
            if (!int.TryParse(Console.ReadLine(), out int year))
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            // Check for valid years (first production car ~1886). Disallow unrealistic future years beyond next year.
            int currentYear = DateTime.Now.Year;
            if (year < 1886 || year > currentYear + 1)
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            Console.Write("Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            // Check for negative values or zero
            if (price <= 0)
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            Console.Write("Color: ");
            if (!Enum.TryParse(Console.ReadLine(), true, out CarColor color))
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            Console.Write("Fuel Capacity (L): ");
            if (!float.TryParse(Console.ReadLine(), out float fuelCapacity))
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            // Create new GasolineCar object and add it to the list
            GasolineCar newCar = new(year, brand!, color, model!, price, fuelCapacity);
            _gasolineCarLists.gasolineCars.Add(newCar);

            _uiManager.ShowAddedCarSuccessMessage("Gasoline Car");
        }

        private void AddElectricCar()
        {
            Console.Clear();
            Console.WriteLine("=== Add New Electric Car ===\n");

            Console.Write("Brand: ");
            string? brand = Console.ReadLine();

            Console.Write("Model: ");
            string? model = Console.ReadLine();

            Console.Write("Year: ");
            if (!int.TryParse(Console.ReadLine(), out int year))
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            // Check for valid years (first production car ~1886). Disallow unrealistic future years beyond next year.
            int currentYear = DateTime.Now.Year;
            if (year < 1886 || year > currentYear + 1)
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            Console.Write("Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            // Check for negative values or zero
            if (price <= 0)
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            Console.Write("Color: ");
            if (!Enum.TryParse(Console.ReadLine(), true, out CarColor color))
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            Console.Write("Battery Capacity (kWh): ");
            if (!float.TryParse(Console.ReadLine(), out float batteryCapacity))
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            // Create new ElectricCar object and add it to the list
            ElectricCar newCar = new(year, brand!, color, model!, price, batteryCapacity);
            _electricCarLists.electricCars.Add(newCar);

            _uiManager.ShowAddedCarSuccessMessage("Electric Car");
        }

        private void AddHybridCar()
        {
            Console.Clear();
            Console.WriteLine("=== Add New Hybrid Car ===\n");

            Console.Write("Brand: ");
            string? brand = Console.ReadLine();

            Console.Write("Model: ");
            string? model = Console.ReadLine();

            Console.Write("Year: ");
            if (!int.TryParse(Console.ReadLine(), out int year))
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            // Check for valid years (first production car ~1886). Disallow unrealistic future years beyond next year.
            int currentYear = DateTime.Now.Year;
            if (year < 1886 || year > currentYear + 1)
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            Console.Write("Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            // Check for negative values or zero
            if (price <= 0)
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            Console.Write("Color: ");
            if (!Enum.TryParse(Console.ReadLine(), true, out CarColor color))
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            Console.Write("Fuel Capacity (L): ");
            if (!float.TryParse(Console.ReadLine(), out float fuelCapacity))
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            Console.Write("Battery Capacity (kWh): ");
            if (!float.TryParse(Console.ReadLine(), out float batteryCapacity))
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            // Create new HybridCar object and add it to the list
            HybridCar newCar = new(year, brand!, color, model!, price, fuelCapacity, batteryCapacity);
            _hybridCarLists.hybridCars.Add(newCar);

            _uiManager.ShowAddedCarSuccessMessage("Hybrid Car");
        }

        private void RemoveCarMenu()
        {
            _uiManager.ShowRemoveCarMenu();
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RemoveGasolineCar();
                    break;
                case "2":
                    RemoveElectricCar();
                    break;
                case "3":
                    RemoveHybridCar();
                    break;
                case "0":
                    return; // Go back to main menu
                default:
                    _uiManager.ShowInvalidChoiceMessage();
                    break;
            }
        }

        private void RemoveGasolineCar()
        {
            Console.Clear();
            Console.WriteLine("=== Remove Gasoline Car ===\n");

            // Show list of gasoline car brands
            var brands = _gasolineCarLists.gasolineCars.Select(car => car.Brand).Distinct().ToList();
            for (int i = 0; i < brands.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {brands[i]}");
            }

            Console.Write("Select a brand (0: Cancel): ");
            if (!int.TryParse(Console.ReadLine(), out int brandChoice) || brandChoice == 0)
            {
                return; // User chose to cancel or entered invalid input
            }

            string? selectedBrand = brands[brandChoice - 1];

            // Show models of the selected brand
            var models = _gasolineCarLists.gasolineCars.Where(c => c.Brand == selectedBrand).ToList();
            for (int i = 0; i < models.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {models[i].Model} ({models[i].Year})");
            }

            // Get user selection for model to remove
            Console.Write("Select a model to remove (0: Cancel): ");
            if (!int.TryParse(Console.ReadLine(), out int modelChoice) || modelChoice == 0)
            {
                return; // User chose to cancel or entered invalid input
            }

            // Remove the selected car from the list
            var carToRemove = models[modelChoice - 1];
            _gasolineCarLists.gasolineCars.Remove(carToRemove);

            _uiManager.ShowRemovedCarSuccessMessage("Gasoline Car");
        }

        private void RemoveElectricCar()
        {
            Console.Clear();
            Console.WriteLine("=== Remove Electric Car ===\n");

            // Show list of electric car brands
            var brands = _electricCarLists.electricCars.Select(car => car.Brand).Distinct().ToList();
            for (int i = 0; i < brands.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {brands[i]}");
            }

            Console.Write("Select a brand (0: Cancel): ");
            if (!int.TryParse(Console.ReadLine(), out int brandChoice) || brandChoice == 0)
            {
                return; // User chose to cancel or entered invalid input
            }

            string? selectedBrand = brands[brandChoice - 1];

            // Show models of the selected brand
            var models = _electricCarLists.electricCars.Where(c => c.Brand == selectedBrand).ToList();
            for (int i = 0; i < models.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {models[i].Model} ({models[i].Year})");
            }

            // Get user selection for model to remove
            Console.Write("Select a model to remove (0: Cancel): ");
            if (!int.TryParse(Console.ReadLine(), out int modelChoice) || modelChoice == 0)
            {
                return; // User chose to cancel or entered invalid input
            }

            // Remove the selected car from the list
            var carToRemove = models[modelChoice - 1];
            _electricCarLists.electricCars.Remove(carToRemove);

            _uiManager.ShowRemovedCarSuccessMessage("Electric Car");
        }

        private void RemoveHybridCar()
        {
            Console.Clear();
            Console.WriteLine("=== Remove Hybrid Car ===\n");

            // Show list of hybrid car brands
            var brands = _hybridCarLists.hybridCars.Select(car => car.Brand).Distinct().ToList();
            for (int i = 0; i < brands.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {brands[i]}");
            }

            Console.Write("Select a brand (0: Cancel): ");
            if (!int.TryParse(Console.ReadLine(), out int brandChoice) || brandChoice == 0)
            {
                return; // User chose to cancel or entered invalid input
            }

            string? selectedBrand = brands[brandChoice - 1];

            // Show models of the selected brand
            var models = _hybridCarLists.hybridCars.Where(c => c.Brand == selectedBrand).ToList();
            for (int i = 0; i < models.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {models[i].Model} ({models[i].Year})");
            }

            // Get user selection for model to remove
            Console.Write("Select a model to remove (0: Cancel): ");
            if (!int.TryParse(Console.ReadLine(), out int modelChoice) || modelChoice == 0)
            {
                return; // User chose to cancel or entered invalid input
            }

            // Remove the selected car from the list
            var carToRemove = models[modelChoice - 1];
            _hybridCarLists.hybridCars.Remove(carToRemove);

            _uiManager.ShowRemovedCarSuccessMessage("Hybrid Car");
        }

        private void UpdateCarPriceMenu()
        {
            _uiManager.ShowUpdatePriceMenu();
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    UpdateGasolineCarPrice();
                    break;
                case "2":
                    UpdateElectricCarPrice();
                    break;
                case "3":
                    UpdateHybridCarPrice();
                    break;
                case "0":
                    return; // Go back to main menu
                default:
                    _uiManager.ShowInvalidChoiceMessage();
                    break;
            }
        }

        private void UpdateGasolineCarPrice()
        {
            Console.Clear();
            Console.WriteLine("=== Update Gasoline Car Price ===");

            // Show list of gasoline car brands
            var brands = _gasolineCarLists.gasolineCars.Select(car => car.Brand).Distinct().ToList();
            for (int i = 0; i < brands.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {brands[i]}");
            }

            Console.Write("Select a brand (0: Cancel): ");
            if (!int.TryParse(Console.ReadLine(), out int brandChoice) || brandChoice == 0)
            {
                return; // User chose to cancel or entered invalid input
            }

            string? selectedBrand = brands[brandChoice - 1];

            // Show models of the selected brand
            var models = _gasolineCarLists.gasolineCars.Where(c => c.Brand == selectedBrand).ToList();
            for (int i = 0; i < models.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {models[i].Model} ({models[i].Year}) - Current Price: {models[i].Price:C}");
            }

            // Get user selection for model to update
            Console.Write("Select a model to update price (0: Cancel): ");
            if (!int.TryParse(Console.ReadLine(), out int modelChoice) || modelChoice == 0)
            {
                return; // User chose to cancel or entered invalid input
            }

            // Update the price of the selected car
            var carToUpdate = models[modelChoice - 1];

            Console.Write($"Enter new price for {carToUpdate.Brand} {carToUpdate.Model}: $");
            if (!decimal.TryParse(Console.ReadLine(), out decimal newPrice))
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            // Check for negative values or zero
            if (newPrice <= 0)
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            carToUpdate.Price = newPrice;

            _uiManager.ShowUpdatedPriceSuccessMessage("Gasoline Car");
        }

        private void UpdateElectricCarPrice()
        {
            Console.Clear();
            Console.WriteLine("=== Update Electric Car Price ===");

            // Show list of electric car brands
            var brands = _electricCarLists.electricCars.Select(car => car.Brand).Distinct().ToList();
            for (int i = 0; i < brands.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {brands[i]}");
            }

            Console.Write("Select a brand (0: Cancel): ");
            if (!int.TryParse(Console.ReadLine(), out int brandChoice) || brandChoice == 0)
            {
                return; // User chose to cancel or entered invalid input
            }

            string? selectedBrand = brands[brandChoice - 1];

            // Show models of the selected brand
            var models = _electricCarLists.electricCars.Where(c => c.Brand == selectedBrand).ToList();
            for (int i = 0; i < models.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {models[i].Model} ({models[i].Year}) - Current Price: {models[i].Price:C}");
            }

            // Get user selection for model to update
            Console.Write("Select a model to update price (0: Cancel): ");
            if (!int.TryParse(Console.ReadLine(), out int modelChoice) || modelChoice == 0)
            {
                return; // User chose to cancel or entered invalid input
            }

            // Update the price of the selected car
            var carToUpdate = models[modelChoice - 1];

            Console.Write("Enter new price for {carToUpdate.Brand} {carToUpdate.Model}: $");
            if (!decimal.TryParse(Console.ReadLine(), out decimal newPrice))
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            // Check for negative values or zero
            if (newPrice <= 0)
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            carToUpdate.Price = newPrice;

            _uiManager.ShowUpdatedPriceSuccessMessage("Electric Car");
        }

        private void UpdateHybridCarPrice()
        {
            Console.Clear();
            Console.WriteLine("=== Update Hybrid Car Price ===");

            // Show list of hybrid car brands
            var brands = _hybridCarLists.hybridCars.Select(car => car.Brand).Distinct().ToList();
            for (int i = 0; i < brands.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {brands[i]}");
            }

            Console.Write("Select a brand (0: Cancel): ");
            if (!int.TryParse(Console.ReadLine(), out int brandChoice) || brandChoice == 0)
            {
                return; // User chose to cancel or entered invalid input
            }

            string? selectedBrand = brands[brandChoice - 1];

            // Show models of the selected brand
            var models = _hybridCarLists.hybridCars.Where(c => c.Brand == selectedBrand).ToList();
            for (int i = 0; i < models.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {models[i].Model} ({models[i].Year}) - Current Price: {models[i].Price:C}");
            }

            // Get user selection for model to update
            Console.Write("Select a model to update price (0: Cancel): ");
            if (!int.TryParse(Console.ReadLine(), out int modelChoice) || modelChoice == 0)
            {
                return; // User chose to cancel or entered invalid input
            }

            // Update the price of the selected car
            var carToUpdate = models[modelChoice - 1];

            Console.Write($"Enter new price for {carToUpdate.Brand} {carToUpdate.Model}: $");
            if (!decimal.TryParse(Console.ReadLine(), out decimal newPrice))
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            // Check for negative values or zero
            if (newPrice <= 0)
            {
                _uiManager.ShowInvalidChoiceMessage();
                return;
            }

            carToUpdate.Price = newPrice;

            _uiManager.ShowUpdatedPriceSuccessMessage("Hybrid Car");
        }

        // Helper method to get user selection and validate it against the number of options available for brands or models. Returns -1 if the user chooses to go back.
        private int GetUserSelection(int maxOptions, string selectionType)
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

                _uiManager.ShowInvalidChoiceMessage();
            }
        }
    }
}
