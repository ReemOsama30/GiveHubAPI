<h1>Clean Architecture Project README</h1>

This repository contains a project built using the Clean Architecture pattern. Clean Architecture is an architectural approach that promotes separation of concerns and maintainability by structuring applications into distinct layers with well-defined responsibilities.

Overview

The project is structured into several layers, each with its own set of responsibilities:

1. Domain Layer: Contains the core business logic and domain entities of the application. It is independent of any external frameworks or libraries.
2. Application Layer: Implements use cases and orchestrates the flow of data between the domain layer and the infrastructure layer. It is responsible for business logic implementation and interacts with external systems via interfaces.
3. Infrastructure Layer: Provides implementations for interacting with external systems such as databases, web services, or external APIs. It contains concrete implementations of repositories, data access objects, and other infrastructure concerns.
4. Presentation Layer: Handles user interface logic and presentation concerns. This can include web controllers, API endpoints, or UI components in a desktop or mobile application.

Project Structure

## Architecture

The application follows the Clean Architecture pattern and is divided into four layers:

1. **Application Layer**: Contains DTOs, configurations, Helper Classes, interfaces, and services.
2. **Presentation Layer**: Contains the MVC controllers and views.
3. **Core Layer**: Contains the entities and enums.
4. **Infrastructure Layer**: Contains the database context, repositories, and UnitOfWork implementation.

### Design Patterns

- **Repository Pattern**: To encapsulate the logic for accessing the data source.
- **UnitOfWork**: To manage database transactions and coordinate the work of multiple repositories.
- **Service Layer**: To encapsulate the business logic of the application and Mapping.
- **AutoMapper**: For object-object mapping between DTOs and entities.


Getting Started

1. Clone the Repository: 
   git clone https://github.com/ReemOsama30/GiveHubAPI.git
   
2. Install Dependencies: 
   cd clean-architecture-project
   dotnet restore
   
3. Build the Project: 
   dotnet build
   
4. Run the Application: 
   dotnet run --project src/Presentation/Presentation.csproj
   



## Team 👥
- [Reem Osama](https://github.com/ReemOsama30).
- [Maria Ezzat](https://github.com/MariaEzat).
- [Sarah Sameh](https://github.com/sarah-sameh).
- [Seravia samuel](https://github.com/SeraviaSamuel).
- [Caroline Emad](https://github.com/carolemad965).
- [Nabila Nabil](https://github.com/Nabila-Nabil).
- [Youstina Emad](https://github.com/YoustinaEmad).
Contributions are welcome! Please read the CONTRIBUTING.md file for guidelines.

License

This project is licensed under the MIT License.


