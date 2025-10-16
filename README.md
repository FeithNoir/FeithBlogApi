# Feith Blog API

Welcome to the Feith Blog API, a .NET 8 backend service designed to manage artists, artworks, and exhibitions. This API provides a complete set of endpoints for CRUD (Create, Read, Update, Delete) operations and includes JWT-based authentication for securing data.

The project is built following modern .NET best practices, including a clean architecture with a clear separation of concerns, dependency injection, and user secrets for configuration.

## Features

- **.NET 8:** Built on the latest long-term support version of .NET.
- **RESTful API:** A complete set of endpoints for managing artists, artworks, and exhibitions.
- **Authentication & Authorization:** Secure endpoints using JSON Web Tokens (JWT).
- **Swagger/OpenAPI Documentation:** Interactive API documentation for easy testing and exploration.
- **Entity Framework Core:** Data access is handled via EF Core with a SQLite database for local development.
- **Clean Architecture:** The solution is structured into three projects:
  - `Api`: The presentation layer, containing controllers.
  - `Business`: The business logic layer, with services and repositories.
  - `Data`: The data access layer, containing the database context and entities.

## Getting Started

### Prerequisites

To run this project locally, you will need:

1.  **[.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)**
2.  **(Optional) Docker Desktop:** If you prefer to run the application in a container.

### Installation & Running

You can run the application either directly with the .NET SDK or using Docker.

#### Method 1: Running with the .NET SDK (Recommended for Development)

1.  **Clone the Repository**

    ```bash
    git clone <your-repository-url>
    cd feithblogapi
    ```

2.  **Set Up User Secrets**

    The application uses a secret key to sign JWT tokens. This key is not stored in the repository for security reasons. You must configure it using the .NET Secret Manager.

    Run the following command in the root directory:
    ```bash
    dotnet user-secrets set "AppSettings:Token" "your-super-secret-key-that-is-long-and-secure"
    ```
    *You can replace the example key with any long, random string.*

3.  **Run the Application**

    ```bash
    dotnet run
    ```

4.  **Access the API**

    The API will be running and listening on **`http://localhost:3000`**.

    To explore and test the endpoints, navigate to the Swagger UI documentation at:
    [**http://localhost:3000/swagger**](http://localhost:3000/swagger)

#### Method 2: Running with Docker

The project includes a `Dockerfile` and a `docker-compose.yml` for easy containerization.

1.  **Clone the Repository**

    ```bash
    git clone <your-repository-url>
    cd feithblogapi
    ```

2.  **Build and Run with Docker Compose**

    This single command will build the Docker image and start the container.
    ```bash
    docker compose up --build
    ```

3.  **Access the API**

    The API will be running inside the container and exposed on **`http://localhost:8081`**.

    To explore and test the endpoints, navigate to the Swagger UI documentation at:
    [**http://localhost:8081/swagger**](http://localhost:8081/swagger)

