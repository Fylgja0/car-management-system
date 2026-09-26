# Car Management System

## 📌 Project Description

The **Car Management System** is a console-based application developed with **C# and .NET**, following Object-Oriented Programming (OOP) principles.

The application allows users to manage different types of cars through a console interface. Users can view cars, add new cars, remove existing cars, and update car prices.

The project started as an OOP-focused application and has been progressively refactored to introduce **database persistence with Entity Framework Core and SQL Server**.

---

## 🚀 Features

* View available cars by type

  * Gasoline
  * Electric
  * Hybrid
* Add new cars
* Remove existing cars
* Update car prices
* Select cars by brand and model
* Calculate driving range according to car type
* Console-based input validation
* Centralized application flow and data management
* Persistent data storage with SQL Server
* Database access through Entity Framework Core
* Code First database migrations
* Automatic initial data seeding

---

## 🛠️ Technologies & Concepts

### Technologies

* **C#**
* **.NET 10**
* **Entity Framework Core**
* **SQL Server**
* **Docker**
* **Git & GitHub**

### Concepts

* Object-Oriented Programming (OOP)
* Classes & Objects
* Inheritance
* Encapsulation
* Polymorphism
* Interfaces
* Generics
* LINQ
* Collections
* Separation of responsibilities
* Database persistence
* Code First migrations
* CRUD operations

---

## 🗄️ Database

The application uses **Microsoft SQL Server** as its persistent data store.

Entity Framework Core is used as the ORM layer between the application and the database.

### Database operations

The application currently supports:

* Creating new car records
* Reading car records
* Updating car prices
* Removing car records
* Initial database seeding

Data persists between application restarts because cars are stored in SQL Server rather than only in memory.

### Entity Framework Core

The database was created using the **Code First** approach.

The project includes:

* `CarManagementDbContext`
* EF Core SQL Server provider
* Initial database migration
* Database model snapshot
* Automatic initial data seeding

The connection string is provided through the `CAR_MANAGEMENT_DB_CONNECTION` environment variable rather than being stored directly in the source code.

---

## 🏗️ Architecture

The project is organized around several responsibilities:

* `Car` — Abstract base class containing common car properties and behavior.
* `GasolineCar` — Represents gasoline-powered vehicles and implements `IFuel`.
* `ElectricCar` — Represents electric vehicles and implements `IElectric`.
* `HybridCar` — Represents hybrid vehicles and implements both `IFuel` and `IElectric`.
* `CarCollection` — Handles car retrieval and CRUD operations through Entity Framework Core.
* `CarManagementDbContext` — Configures Entity Framework Core and provides access to the SQL Server database.
* `UIManager` — Handles console input and output.
* `UXManager` — Controls application flow and coordinates user actions.
* `Program` — Application entry point.

This structure keeps the **UI, application flow, domain models, and data access responsibilities separated**.

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
│   ├── CarCollection.cs
│   └── CarManagementDbContext.cs
│
├── Interface
│   ├── IElectric.cs
│   └── IFuel.cs
│
├── Enums
│   └── CarColor.cs
│
├── Migrations
│   ├── 20260925093425_InitialCreate.cs
│   ├── 20260925093425_InitialCreate.Designer.cs
│   └── CarManagementDbContextModelSnapshot.cs
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

* .NET 10 SDK
* SQL Server
* Docker (if running SQL Server in a container)
* Git

### 1. Clone the repository

```bash
git clone https://github.com/Fylgja0/car-management-system.git
cd car-management-system
```

### 2. Configure the database connection

Set the `CAR_MANAGEMENT_DB_CONNECTION` environment variable with your own SQL Server connection string.

Example:

```bash
export CAR_MANAGEMENT_DB_CONNECTION='Server=localhost,1433;Database=CarManagementDb;User Id=sa;Password=YOUR_PASSWORD;TrustServerCertificate=True;'
```

> Do not commit your actual password or connection string containing credentials to the repository.

### 3. Restore dependencies

```bash
dotnet restore
```

### 4. Apply database migrations

```bash
dotnet ef database update
```

### 5. Run the application

```bash
dotnet run
```

---

## 🎮 Usage

When the application starts, the console menu allows the user to:

1. View gasoline cars
2. View electric cars
3. View hybrid cars
4. Add a new car
5. Remove a car
6. Update a car's price
7. Exit the application

When adding, removing, or updating a car, the application guides the user through the required selections.

All changes are persisted to the SQL Server database.

---

## 🎯 Purpose of the Project

This project is a **learning and portfolio project** focused on developing practical C# and backend development skills.

The project is being developed incrementally, starting with fundamental OOP concepts and evolving toward a more realistic backend application.

Current learning focus areas include:

* Applying OOP principles in a complete application
* Inheritance, interfaces, and polymorphism
* Encapsulation and separation of responsibilities
* Collections and LINQ
* Refactoring for maintainability
* Entity Framework Core
* SQL Server
* Database persistence
* Code First migrations
* CRUD operations
* Building a foundation for future backend/API development

---

## 🔮 Future Improvements

Planned improvements include:

* Unit testing
* Search and filtering
* Sorting by price, year, or range
* More advanced validation
* ASP.NET Core Web API
* HTTP/REST API integration
* Authentication and authorization
* Cloud deployment

---

## 👨‍💻 Author

Developed by **Fylgja0**
