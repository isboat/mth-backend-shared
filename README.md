# MemeTokenHub.Shared

[![Build and Publish to GitHub Packages](https://github.com/your-org/mth-backend-shared/actions/workflows/build-and-publish.yml/badge.svg)](https://github.com/your-org/mth-backend-shared/actions/workflows/build-and-publish.yml)

Shared library for MemeTokenHub backend microservices. This NuGet package contains reusable components across all services including DTOs, exception handling, JWT utilities, MongoDB base repository, and configuration helpers.

## Package Information.

- **NuGet Package**: `MemeTokenHub.Shared`
- **Source**: GitHub Packages
- **.NET Target**: .NET 8.0
- **License**: MIT

## Features

- ✅ **DTOs** - User, Token, Claim, Social, Payment data transfer objects
- ✅ **Exception Handling** - Custom exceptions with error codes
- ✅ **JWT Authentication** - Token generation and validation
- ✅ **MongoDB Data Access** - Base repository pattern with CRUD operations
- ✅ **Configuration** - MongoDB and Azure Service Bus setup helpers
- ✅ **Logging** - Shared logging abstraction
- ✅ **Messaging** - Event contracts for Azure Service Bus
- ✅ **Extensions** - Dependency injection and utility extensions

## Installation

See [PACKAGE.md](docs/PACKAGE.md) for detailed installation and usage instructions.

### Quick Start

Add to your `.csproj`:

```xml
<ItemGroup>
  <PackageReference Include="MemeTokenHub.Shared" Version="1.0.x" />
</ItemGroup>
```

Or via CLI:

```bash
dotnet add package MemeTokenHub.Shared
```

## Usage

Register shared services in your `Program.cs`:

```csharp
using MemeTokenHub.Shared.Extensions;
using MemeTokenHub.Shared.Configuration;

builder.Services.AddSharedServices(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddMongoDb(connectionString, databaseName);
```

## Project Structure

```
src/
├── Dtos/              # Data transfer objects
├── Exceptions/        # Custom exceptions
├── Constants/         # Shared constants and enums
├── Auth/              # JWT authentication services
├── Data/              # MongoDB base repository
├── Configuration/     # Service configuration
├── Logging/           # Logging abstraction
├── Messaging/         # Event messaging contracts
└── Extensions/        # DI and utility extensions
```

## CI/CD

This project uses GitHub Actions for automated:
- Building
- Testing (when test projects are added)
- Publishing to GitHub Packages

See [GITHUB-SETUP.md](docs/GITHUB-SETUP.md) for setup and configuration details.

### Workflow Triggers

- **Main branch**: Releases version `1.0.{build-number}`
- **Develop branch**: Pre-releases version `1.0.{build-number}-preview`
- **Pull requests**: Builds only (no publish)

## Documentation

- [PACKAGE.md](docs/PACKAGE.md) - Package usage and installation
- [GITHUB-SETUP.md](docs/GITHUB-SETUP.md) - GitHub and CI/CD setup
- [Shared Library Details](docs/mth-docs/doc/backend/shared-library-instructions.md) - Architecture and component details

## Contributing

1. Create a feature branch
2. Make your changes
3. Push to develop branch
4. Create a pull request to main
5. After merge, GitHub Actions will publish the package

## Development

### Prerequisites

- .NET 8.0 SDK or later
- MongoDB (for local testing)
- Git

### Build

```bash
dotnet build src/MemeTokenHub.Shared.csproj
```

### Test

```bash
# Add test project when available
dotnet test tests/
```

## Support

For issues or questions:
1. Check existing GitHub issues
2. Create a new issue with details
3. Contact the MemeTokenHub team

## License

MIT License - See LICENSE file
