using Microsoft.Extensions.DependencyInjection;
using SD.Mini.Zoo.Domain.Services;
using SD.Mini.Zoo.Domain.Services.Interfaces;

namespace SD.Mini.Zoo.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IZooKeeperService, ZooKeeperService>();
        services.AddScoped<IAnimalVetService, AnimalVetService>();
        return services;
    }
}