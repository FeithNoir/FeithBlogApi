# Feith Artist Blog Blueprint

## Overview

This project is a full-stack web application for an artist's blog and portfolio. It is built using ASP.NET Core MVC, Entity Framework Core, and SQLite. The application will allow the artist to showcase their work, write blog posts, and announce exhibitions.

## Project Outline

### Technologies

*   **Backend:** ASP.NET Core MVC
*   **Database:** SQLite (Development), PostgreSQL (Production - Recommended)
*   **ORM:** Entity Framework Core
*   **Frontend:** Razor Pages
*   **API Documentation:** Swagger (OpenAPI)
*   **Authentication:** JWT

### Project Structure

*   `feithblogapi.csproj`: The main project file.
*   `Program.cs`: The application's entry point, where services are configured.
*   `appsettings.json`: Configuration file for the application.
*   `Controllers/`: Contains the MVC controllers for handling web requests.
*   `Models/`: Contains the data models (POCOs) for the application.
*   `Views/`: Contains the Razor views for the application.
*   `Data/`: Contains the `BlogContext` for interacting with the database.
*   `Business/`: Contains the business logic services.
*   `Core/`: Contains core entities and DTOs.

## Current Change: API Implementation and Core Features

### Plan

1.  **Add Swagger for API Documentation:**
    *   Install the `Swashbuckle.AspNetCore` NuGet package.
    *   Configure Swagger in `Program.cs` to generate API documentation.

2.  **Implement Authentication with JWT:**
    *   Create a `User` model for user registration and login.
    *   Add the `User` model to the `BlogContext` and create a database migration.
    *   Create an `AuthController` with `Register` and `Login` endpoints.
    *   Generate a JWT upon successful login.
    *   Configure JWT authentication in `Program.cs`.

3.  **Create API Controllers:**
    *   Create API controllers for `Artists`, `Artworks`, `Posts`, and `Exhibitions`.
    *   Implement GET, POST, PUT, and DELETE endpoints for each resource.
    *   Use the existing services from the `Business` layer.
    *   Add `SemaphoreSlim` to service methods to ensure thread safety.

4.  **Create Basic Frontend with Razor Pages:**
    *   Create Razor Pages to display lists of artists, artworks, posts, and exhibitions.
    *   Create pages for viewing individual items.

5.  **Configure Production Database (PostgreSQL):**
    *   Add the `Npgsql.EntityFrameworkCore.PostgreSQL` NuGet package.
    *   Configure the application to use PostgreSQL in the production environment and SQLite in development. This provides a more robust and scalable database solution for production. There is no official Entity Framework Core provider for Firebase, so PostgreSQL is a recommended alternative.
