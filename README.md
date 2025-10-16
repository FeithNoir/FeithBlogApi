# Feith Blog: Full-Stack Application

Welcome to the Feith Blog, a full-stack web application built with a .NET 8 backend and a Vue.js frontend. This project is designed to provide a modern, performant, and secure platform for artists to create and manage their blog posts.

The application follows a clean architecture with a strong separation of concerns, uses JWT-based authentication, and leverages Entity Framework Core for data persistence.

## Features

- **Full-Stack Solution:** A complete web application with a .NET backend and a Vue.js frontend.
- **.NET 8 Backend:** Built on the latest long-term support version of .NET, providing a robust and scalable foundation.
- **Vue.js Frontend:** A reactive and modern user interface for a seamless user experience.
- **RESTful API:** A comprehensive set of API endpoints for managing blog posts.
- **Authentication & Authorization:** Secure endpoints using JSON Web Tokens (JWT) to ensure that only authenticated artists can create or modify posts.
- **Entity Framework Core:** Data access is managed through EF Core with a SQLite database for local development.
- **Clean Architecture:** The solution is structured into distinct layers:
  - `Api`: The presentation layer, containing API controllers.
  - `Business`: The application layer, holding business logic and services.
  - `Core`: The domain layer, containing core entities, DTOs, and models.
  - `Data`: The infrastructure layer, managing data access with EF Core.

## Getting Started

### Prerequisites

To run this project, you will need the **.NET 8 SDK**, which is pre-installed in this development environment.

### Running the Application

1.  **Set Up User Secrets**

    The application uses a secret key to sign JWT tokens. This key is not stored in the repository for security. To run the application, you must first configure the secret key.

    Execute the following command in the terminal:
    ```bash
    dotnet user-secrets set "Jwt:Key" "your-super-secret-key-that-is-long-and-secure-enough"
    dotnet user-secrets set "Jwt:Issuer" "your-issuer"
    dotnet user-secrets set "Jwt:Audience" "your-audience"
    ```
    *You can replace the example values with your own secure key, issuer, and audience.*

2.  **Run the Dev Server**

    To start both the backend and frontend, simply run the following command:
    ```bash
    dotnet watch
    ```
    This command will build the application, start the web server, and automatically watch for any file changes.

3.  **Access the Application**

    Once the server is running, the web application will be available in the **Web Preview** tab in your IDE. You can access it directly to view and interact with the blog.

