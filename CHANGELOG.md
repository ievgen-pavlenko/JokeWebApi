# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [1.0.1] - 2025-09-28

### Added
- Functionality to request jokes in different languages (`Ukrainian`, `English`, `Polish`).
- Validation for supported languages, with a fallback to the default language (`Ukrainian`).
- Comprehensive XML documentation for all public classes and methods.
- A `Constants.cs` file to centralize application-wide constants.
- An API schema diagram in `README.md`.
- This `CHANGELOG.md` file.
- Versioning information (`1.0.1`) to the `.csproj` file.

### Changed
- Refactored `AiClient` to use the `IOptions<AzureOpenAiSettings>` pattern, decoupling it from `IConfiguration` and improving testability.
- The system now gracefully handles requests for unsupported languages by falling back to the default language.
- Made the `ModelDeploymentName` configurable via `appsettings.json` or environment variables.
- Renamed the `ModelDeploymentName` constant to `DefaultModelDeploymentName` for better clarity.
- Updated `README.md` with details about the new language and configuration features.

## [1.0.0] - 2025-09-27

### Added
- Initial project setup with a simple ASP.NET 8 Web API.
- Integration with Azure OpenAI to generate jokes in Ukrainian.
- Docker support for containerization.
- Basic `README.md` and Swagger/OpenAPI documentation.
