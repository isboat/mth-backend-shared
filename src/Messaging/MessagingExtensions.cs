using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MemeTokenHub.Shared.Messaging;

public static class MessagingExtensions
{
    public static IServiceCollection AddServiceBusMessaging(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(provider =>
            new ServiceBusClient(configuration["ServiceBus:ConnectionString"] 
                ?? throw new InvalidOperationException("ServiceBus:ConnectionString not configured")));

        return services;
    }
}
