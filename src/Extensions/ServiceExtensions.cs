using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MemeTokenHub.Shared.Auth;
using MemeTokenHub.Shared.Logging;

namespace MemeTokenHub.Shared.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddSharedServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITokenService, JwtTokenService>();
        services.AddScoped<IAppLogger, AppLogger>();

        return services;
    }
}
