# Car Management System

## 📌 Project Description

The **Car Management System** is a console-based application developed with **C#** and **Object-Oriented Programming (OOP)** principles.

The application allows users to manage different types of cars through a simple console interface. Users can view cars, add new cars, remove existing cars, and update car prices.

The project was developed as a practical exercise in **OOP, encapsulation, inheritance, interfaces, polymorphism, generics, LINQ, and code organization**.

---

## 🚀 Features

- View available cars by type
- Add new cars
  - Gasoline
  - Electric
  - Hybrid
- Remove cars
- Update car prices
- Select cars by brand and model
- Calculate driving range according to car type
- Console-based input validation
- Centralized car collection management

---

## 🛠️ Technologies & Concepts

- **C#**
- **.NET**
- **Object-Oriented Programming (OOP)**
- Classes & Objects
- Inheritance
- Encapsulation
- Interfaces
- Polymorphism
- Generics
- LINQ
- Collections
- Separation of responsibilities

---

## 🏗️ Architecture

The project is organized around a small set of responsibilities:

- **`Car`** — Abstract base class containing common car properties and behavior.
- **`GasolineCar`** — Represents gasoline-powered vehicles and implements `IFuel`.
- **`ElectricCar`** — Represents electric vehicles and implements `IElectric`.
- **`HybridCar`** — Represents hybrid vehicles and implements both `IFuel` and `IElectric`.
- **`CarCollection`** — Centralizes car storage and provides operations for retrieving, adding, and removing cars.
- **`UIManager`** — Handles console UI, input, and output.
- **`UXManager`** — Controls application flow and coordinates user actions.
- **`Program`** — Application entry point.

This structure keeps the console UI separate from the car models and collection management.

---

## 📂 Project Structure

```text
CarProject_OOP
│
├── Base
│   └── Car.cs
│
├── Concrete
│   ├── GasolineCar.cs
│   ├── ElectricCar.cs
│   └── HybridCar.cs
│
├── Data
│   └── CarCollection.cs
│
├── Interface
│   ├── IElectric.cs
│   └── IFuel.cs
│
├── Enums
│   └── CarColor.cs
│
├── Procedure
│   ├── UIManager.cs
│   └── UXManager.cs
│
└── Program.cs
```

---

## ▶️ How to Run

### Prerequisites

- .NET SDK
- Visual Studio or another C#/.NET compatible IDE

### Run the project

Clone the repository:

```bash
git clone https://github.com/Fylgja0/car-management-system.git
```

Navigate to the project directory and run:

```bash
dotnet run
```

Alternatively, open the project in **Visual Studio**, build it, and run the application.

---

## 🎮 Usage

When the application starts, the console menu allows you to:

1. View gasoline cars
2. View electric cars
3. View hybrid cars
4. Add a new car
5. Remove a car
6. Update a car's price
7. Exit the application

When adding, removing, or updating a car, the application guides the user through the required selections.

---

## 🎯 Purpose of the Project

This project is primarily a **learning and portfolio project** created to strengthen practical C# skills.

The main focus areas are:

- Applying OOP principles in a complete application
- Practicing inheritance, interfaces, and polymorphism
- Improving encapsulation and separation of responsibilities
- Working with collections and LINQ
- Refactoring existing code to improve structure and maintainability

---

## 🔮 Future Improvements

Possible future improvements include:

- Unit testing
- Database integration with SQL Server
- Persistent data storage
- Search and filtering
- Sorting by price, year, or range
- More advanced validation
- A backend/API version of the application

---

## 👨‍💻 Author

Developed by **Fylgja**
