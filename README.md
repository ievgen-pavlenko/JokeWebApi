# Joke Web API

This is a simple ASP.NET 8 Web API that generates jokes using Azure OpenAI Service.

## Features

- A single endpoint `/api/getJoke` that accepts a POST request.
- Integrates with Azure OpenAI to generate jokes based on a predefined system prompt.
- Supports configuration via `appsettings.json` and environment variables.
- Includes Swagger/OpenAPI documentation.
- Provides a `Dockerfile` for containerization.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/products/docker-desktop/) (optional, for containerized deployment)

## Configuration

The application requires credentials for the Azure OpenAI service. These can be configured in two ways:

### 1. appsettings.json

Fill in the `AzureOpenAI` section in the `JokeWebApp/appsettings.json` file:

```json
{
  "AzureOpenAI": {
    "Endpoint": "https://your-azure-endpoint.com",
    "ApiKey": "YOUR_SECRET_API_KEY"
  }
}
```

### 2. Environment Variables

You can provide the configuration via environment variables. This is the recommended approach for production and Docker deployments. The double underscore `__` is used as a separator.

- `AzureOpenAI__Endpoint`
- `AzureOpenAI__ApiKey`

## How to Run

### Locally with .NET CLI

1.  Navigate to the project directory: `cd JokeWebApp`
2.  Run the application:
    ```bash
    dotnet run
    ```
3.  The API will be available at `http://localhost:<port>`, and the Swagger UI at `http://localhost:<port>/swagger`.

### With Docker

1.  **Build the image:**
    From the root directory (`joke-web`), run:
    ```bash
    docker build -t joke-api .
    ```

2.  **Run the container:**
    Replace the placeholder values with your actual Azure credentials.
    ```bash
    docker run -d -p 8080:8080 \
      -e AzureOpenAI__Endpoint="https://your-azure-endpoint.com" \
      -e AzureOpenAI__ApiKey="YOUR_SECRET_API_KEY" \
      --name joke-api-container \
      joke-api
    ```
3.  The API will be available at `http://localhost:8080`.

## API Usage

Send a POST request to the `/api/getJoke` endpoint.

**Request Body:**

```json
{
  "input": "Any text here"
}
```

**Example with cURL:**

```bash
cURL -X POST http://localhost:8080/api/getJoke \
-H "Content-Type: application/json" \
-d '{"input": "Розкажи жарт"}'
```

**Success Response (200 OK):**

```json
{
  "response": "Чому програмісти плутають Хелловін та Різдво? Тому що 31 OCT = 25 DEC."
}
```
