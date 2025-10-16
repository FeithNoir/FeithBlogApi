### Overview
This project is a .NET Core Web API for a blog. It includes authentication with JWT and will eventually have endpoints for managing blog posts, artists, artworks, and exhibitions.

### Project Structure
*   `Api/Controllers`: Contains API controllers.
*   `Business/Repositories`: Contains data access logic.
*   `Core/Models`: Contains data models and DTOs.
*   `Data`: Contains the Entity Framework Core `DbContext` and migrations.
*   `Views`: Contains Razor views (for potential future web UI).
*   `wwwroot`: Contains static assets.

### Implemented Features & Design
*   **Authentication:**
    *   JWT-based authentication.
    *   `AuthController` with `register` and `login` endpoints.
    *   `AuthRepository` for user registration and login logic.
    *   Password hashing using HMACSHA512.
*   **Database:**
    *   Entity Framework Core with SQLite for local development.
    *   `BlogContext` as the `DbContext`.
*   **API:**
    *   Swagger/OpenAPI documentation.
    *   CORS enabled to allow all origins.

### Current Task: Initial Setup and Authentication

**Plan:**
1.  **DONE** Install NuGet packages:
    *   `FirebaseDatabase.net`
    *   `Microsoft.AspNetCore.Authentication.JwtBearer`
    *   `Swashbuckle.AspNetCore` (already installed)
2.  **DONE** Configure `Program.cs`:
    *   Add JWT authentication.
    *   Add Swagger configuration for JWT.
    *   Add CORS policy.
    *   Add Firebase configuration placeholder.
3.  **DONE** Configure `appsettings.json`:
    *   Add `AppSettings:Token` for the JWT secret key.
    *   Add `Firebase` configuration section.
4.  **DONE** Create `AuthController.cs` in `Api/Controllers`.
5.  **DONE** Update `IAuthRepository.cs` and `AuthRepository.cs`.
    *   Implement `Register` and `Login` methods with `ServiceResponse`.
    *   Implement JWT generation.
6.  **DONE** Create `ServiceResponse.cs` model.
7.  **DONE** Create and update `blueprint.md`.
