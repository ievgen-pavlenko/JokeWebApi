# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY JokeWebApp/JokeWebApp.csproj JokeWebApp/
RUN dotnet restore JokeWebApp/JokeWebApp.csproj

# Copy the rest of the application source code
COPY JokeWebApp/ JokeWebApp/

# Build the application
RUN dotnet publish JokeWebApp/JokeWebApp.csproj -c Release -o /app/publish

# Stage 2: Create the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expose the port the app runs on (8080 is the default for .NET 8+ containers)
EXPOSE 8080

# Entry point to run the application
ENTRYPOINT ["dotnet", "JokeWebApp.dll"]
