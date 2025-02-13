using Microsoft.Extensions.DependencyInjection;
using SD.Mini.Zoo.Console.Controllers;

namespace SD.Mini.Zoo.Console.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddControllers(this IServiceCollection services)
    {
        services.AddScoped<ZooKeeperController>();
        return services;
    }
}