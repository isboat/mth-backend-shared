# MemeTokenHub.Shared NuGet Package

This is a GitHub Package that contains shared libraries for all MemeTokenHub backend microservices.

## Package Details

- **Package Name**: `MemeTokenHub.Shared`
- **Source**: GitHub Packages (ghcr.io)
- **Repository**: [GitHub](https://github.com/your-org/mth-backend-shared)

## How to Consume

### 1. Configure NuGet to Use GitHub Packages

Create or update `NuGet.config` in your service project:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear />
    <add key="github" value="https://nuget.pkg.github.com/YOUR_GITHUB_ORG/index.json" />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
  </packageSources>
  <packageSourceCredentials>
    <github>
      <add key="Username" value="YOUR_GITHUB_USERNAME" />
      <add key="ClearTextPassword" value="YOUR_GITHUB_TOKEN" />
    </github>
  </packageSourceCredentials>
</configuration>
```

### 2. Add Package Reference

Add a reference to the package in your `.csproj` file:

```xml
<ItemGroup>
  <PackageReference Include="MemeTokenHub.Shared" Version="1.0.x" />
</ItemGroup>
```

Or use the CLI:

```bash
dotnet add package MemeTokenHub.Shared --version 1.0.x
```

### 3. Set Up GitHub Token

Create a GitHub Personal Access Token (PAT) with `read:packages` scope:

1. Go to GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)
2. Click "Generate new token"
3. Select `read:packages` scope
4. Copy the token

### 4. Use in Your Service

Register the shared services in your `Program.cs`:

```csharp
using MemeTokenHub.Shared.Extensions;
using MemeTokenHub.Shared.Configuration;

var builder = WebApplicationBuilder.CreateBuilder(args);

// Add shared services
builder.Services.AddSharedServices(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddMongoDb(
    builder.Configuration["MongoDB:ConnectionString"]!,
    builder.Configuration["MongoDB:DatabaseName"]!);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
```

### 5. Configure appsettings.json

Add required settings to your `appsettings.json`:

```json
{
  "Jwt": {
    "SecretKey": "your-secret-key-min-32-chars-long",
    "Issuer": "MemeTokenHub",
    "Audience": "MemeTokenHubAPI"
  },
  "MongoDB": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "MemeTokenHubDB"
  },
  "ServiceBus": {
    "ConnectionString": "Endpoint=sb://your-namespace.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=your-key"
  }
}
```

## Features

- **DTOs**: User, Token, Claim, Social, Payment data transfer objects
- **Exceptions**: Custom exception handling with error codes
- **Authentication**: JWT token generation and validation
- **Data Access**: MongoDB base repository pattern
- **Configuration**: MongoDB and Service Bus setup helpers
- **Logging**: Shared logging abstraction
- **Messaging**: Event contracts for Azure Service Bus
- **Extensions**: Dependency injection and utility extensions

## CI/CD

The package is automatically built and published to GitHub Packages on:
- Push to `main` branch (releases)
- Push to `develop` branch (previews)

Version format:
- Main: `1.0.{build-number}`
- Develop: `1.0.{build-number}-preview`

## GitHub Actions Workflow

The project includes automated CI/CD:
1. **Build**: Compiles the project
2. **Test**: Runs unit tests (if present)
3. **Pack**: Creates NuGet package
4. **Publish**: Pushes to GitHub Packages

## Troubleshooting

### Authentication Issues

```bash
# Clear NuGet cache
nuget locals all -clear

# Restore with verbose output
dotnet restore --verbosity diagnostic
```

### Package Not Found

- Ensure your GitHub token has `read:packages` permission
- Verify the package source URL is correct
- Check that your GitHub organization is correct

## Contributing

When updating the shared library:
1. Make changes to the main branch
2. Push the changes
3. The GitHub Action will automatically build, test, and publish
4. Services can then update their package reference

## License

MIT License - See LICENSE file for details
