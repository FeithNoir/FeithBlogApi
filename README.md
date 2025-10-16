# Feith Blog: Full-Stack Application

Welcome to the Feith Blog, a full-stack web application built with a .NET 8 backend. This project is designed to provide a modern, performant, and secure platform for users to register and log in.

The application follows a clean architecture with a strong separation of concerns, uses JWT-based authentication, and leverages Entity Framework Core for data persistence.

## Features

- **.NET 8 Backend:** Built on the latest long-term support version of .NET, providing a robust and scalable foundation.
- **RESTful API:** A comprehensive set of API endpoints for user authentication.
- **Authentication & Authorization:** Secure endpoints using JSON Web Tokens (JWT) to ensure that only authenticated users can access protected resources.
- **Entity Framework Core:** Data access is managed through EF Core with a SQLite database for local development.
- **Repository Pattern:** The data access layer uses the repository pattern for a clean separation of concerns.
- **Clean Architecture:** The solution is structured into distinct layers:
  - `Api`: The presentation layer, containing API controllers.
  - `Business`: Contains the repository implementations.
  - `Core`: The domain layer, containing core entities, interfaces for repositories, and DTOs.
  - `Data`: The infrastructure layer, managing the database context and migrations with EF Core.

## Getting Started

### Prerequisites

To run this project, you will need the **.NET 8 SDK**, which is pre-installed in this development environment.

### Running the Application

1.  **Set Up User Secrets**

    The application uses a secret key to sign JWT tokens. This key is not stored in the repository for security. To run the application, you must first configure the secret key.

    Execute the following command in the terminal:
    ```bash
    dotnet user-secrets set "AppSettings:Token" "your-super-secret-key-that-is-long-and-secure-enough"
    ```
    *You can replace the example value with your own secure key.*

2.  **Run the Dev Server**

    To start the backend, simply run the following command:
    ```bash
    dotnet watch
    ```
    This command will build the application, start the web server, and automatically watch for any file changes.

3.  **Access the Application**

    Once the server is running, the API will be available. You can use tools like Swagger, available at `/swagger` in the web preview, to interact with the API endpoints.

## Database Management

This project uses **Entity Framework Core** to manage the database schema through migrations.

### Migrations Folder

The `Data/Migrations` folder is intentionally excluded from source control via the `.gitignore` file. This is a common practice to prevent conflicts between developers' local database schemas. Each developer is responsible for creating and managing their own local database.

### Creating and Applying Migrations

When you make changes to the entity models in the `Core` project (e.g., the `User` model), you will need to create a new migration and apply it to your database.

1.  **Create a Migration:**
    Use the following command to create a migration. The `--project Data` flag is necessary because the `DbContext` is in a different project than the startup project.
    ```bash
    dotnet ef migrations add InitialCreate --project Data
    ```
    Replace `InitialCreate` with a descriptive name for your migration.

2.  **Apply the Migration:**
    This command applies any pending migrations to your database, creating or updating the schema.
    ```bash
    dotnet ef database update
    ```
