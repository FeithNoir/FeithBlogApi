# Stage 1: Build the application
# We use the official .NET 8 SDK image which contains all the tools to build the app.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file first and restore dependencies. 
# This is a Docker optimization. As long as the .csproj file doesn't change, Docker will use a cached layer for the dependencies, speeding up subsequent builds.
COPY myapp.csproj .
RUN dotnet restore "myapp.csproj"

# Copy the rest of the source code
COPY . .

# Publish the application to a specific folder, ready for deployment.
# We build in "Release" mode for production performance.
RUN dotnet publish "myapp.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Create the final, smaller runtime image
# We use the ASP.NET runtime image, which is much smaller than the SDK image because it doesn't contain the compilers.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy the published build from the "build" stage
COPY --from=build /app/publish .

# Expose port 8080 to the outside world. Kestrel will listen on this port.
EXPOSE 8080

# Set the environment variable to make ASP.NET Core listen on the exposed port.
ENV ASPNETCORE_URLS=http://*:8080

# The command to run the application when the container starts.
ENTRYPOINT ["dotnet", "myapp.dll"]
