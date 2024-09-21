
# ECommerceApp

## Overview

ECommerceApp is a robust, modular, and scalable e-commerce platform developed using ASP.NET Core and follows Clean Architecture principles. It supports key e-commerce functionality such as user management, product management, commenting, and role-based access control, making it easy to extend and integrate with other services.

The project utilizes a layered architecture with the core business logic, infrastructure, and presentation layers being decoupled. This architecture promotes separation of concerns and allows for easier testing, maintenance, and future scalability.

## Technologies Used

- **ASP.NET Core 8.0**: For building the web API.
- **Entity Framework Core**: ORM for database interaction.
- **SQL Server**: Primary database for storing all application data.
- **MediatR**: For implementing the Mediator pattern and handling commands and queries.
- **Swagger/OpenAPI**: For API documentation and exploration.
- **FluentValidation**: For validating requests.
- **AutoMapper**: For mapping between different object models (DTOs and domain models).
- **JWT Authentication**: For secure token-based authentication and authorization.
- **Azure App Services**: For cloud deployment (optional).
- **Unit Testing Frameworks**: For unit and integration testing (XUnit, Moq).

## Project Structure

The solution is divided into several key components:

### 1. Core

- **ECommerceAPI.Application**: Contains the core application logic, including service interfaces, commands, queries, handlers, and application-specific DTOs. The Mediator pattern is used for CQRS, and each operation (e.g., CreateProductCommand) is encapsulated within its handler.
  
  - **Commands & Queries**: Defined for all major operations such as adding products, managing users, and adding comments.
  
  - **Validators**: Input validation is handled using FluentValidation, ensuring that data entering the system meets predefined requirements.
  
- **ECommerceAPI.Domain**: Defines the core domain entities such as `Product`, `User`, and `Comment`. These models include business logic and relationships.

### 2. Infrastructure

- **ECommerceAPI.Infrastructure**: Manages infrastructure concerns, such as integrating third-party services (e.g., email services), logging, and caching mechanisms.
  
- **ECommerceAPI.Persistence**: Manages the database layer, including repository implementations, Entity Framework DbContext, and migrations.
  
  - **Repositories**: Each entity has its corresponding repository for data access, supporting CRUD operations and queries.
  
  - **Database Configuration**: Migrations and seeding are handled here to ensure the database schema matches the domain models.

### 3. Presentation

- **ECommerceAPI.API**: Contains the ASP.NET Core controllers that expose the API endpoints for interacting with the system. The API follows RESTful principles and includes secure authentication via JWT.

  - **Controllers**: Product, User, and Comment controllers handle incoming HTTP requests. Role-based access control is enforced on these routes.
  
  - **Middleware**: Custom middleware for error handling, logging, and authentication.
  
  - **Swagger**: API documentation is automatically generated and accessible via Swagger UI at `/swagger`.

## Key Features

1. **User Management**: Users can register, log in, and be assigned roles. JWT tokens are used for authentication, and role-based authorization determines access to specific features.
  
2. **Product Management**: Admin users can add, update, and delete products. Regular users can view products.
  
3. **Commenting System** (in progress): Users can leave comments on products. Comments can be moderated by admins.
  
4. **Role-Based Access Control (RBAC)**: Access to resources and actions is controlled by user roles. Admins have elevated permissions for managing users and products.
  
5. **Token-Based Authentication**: Secure authentication using JWT tokens. Each request requires a valid token to be processed, ensuring secure API access.

6. **Clean Architecture**: Separation of concerns between domain, application, infrastructure, and presentation layers ensures scalability and maintainability.

7. **MediatR for CQRS**: All operations (queries and commands) are handled by dedicated handlers following the CQRS pattern.

## Database Design

The application uses SQL Server as the primary data store. The database includes tables for:

- **Users**: Stores user data including role information.
- **Products**: Stores product details such as name, price, description, etc.
- **Comments**: Stores comments linked to products and users.
  
Entity Framework is used as the ORM to manage the database interactions, and migrations are used to handle schema changes over time.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or a compatible database system.
- Optional: [Azure App Service](https://azure.microsoft.com/en-us/services/app-service/) for cloud hosting.

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/ECommerceApp.git
   cd ECommerceApp
   ```

2. Restore NuGet packages:
   ```bash
   dotnet restore
   ```

3. Update the connection string in `appsettings.json` (located in `ECommerceAPI.API`):
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=your_server_name;Database=your_database_name;User Id=your_username;Password=your_password;"
   }
   ```

4. Apply migrations:
   ```bash
   dotnet ef database update --project Infrastructure/ECommerceAPI.Persistence
   ```

5. Run the project:
   ```bash
   dotnet run --project TestAPI/ECommerceAPI.API
   ```

6. Navigate to `http://localhost:{yourlocalhost}/swagger` to explore the API documentation via Swagger.

## Testing

Unit and integration tests are provided in the solution. To run the tests:

```bash
dotnet test
```

The testing framework used is XUnit, with Moq for mocking dependencies in unit tests. The tests cover the application's services, commands, and queries.

## Deployment

### Local Deployment

Run the application locally using the steps above. For local deployment, ensure SQL Server is installed and configured properly, and the connection string points to your local server.

### Azure App Service Deployment

1. Create a new App Service in your Azure portal.
2. Configure the environment variables for your connection strings and JWT settings.
3. Deploy the project using Visual Studio or GitHub Actions.

For continuous integration and deployment (CI/CD), the project can be set up with GitHub Actions to automate builds, tests, and deployments.

## Extending the Project

This application is designed to be modular and extendable. To add new features:

- **New Features**: Create new command and query handlers in the `ECommerceAPI.Application` layer following the existing pattern.
  
- **New Endpoints**: Add controllers in `ECommerceAPI.API` and map them to the handlers via dependency injection.
  
- **New Models**: Update the domain models and the corresponding repositories and migrations in `ECommerceAPI.Persistence`.

## Contributing

Contributions are welcome! To contribute:

1. Fork the repository.
2. Create a feature branch (`git checkout -b feature/YourFeature`).
3. Commit your changes (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature/YourFeature`).
5. Create a new Pull Request.

## License

This project is licensed under the MIT License.
