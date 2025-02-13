using Microsoft.Extensions.DependencyInjection;
using SD.Mini.Zoo.Domain.Contracts.Dal.Interfaces;
using SD.Mini.Zoo.Infrastructure.Dal.Repositories;

namespace SD.Mini.Zoo.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDalRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IAnimalsRepository, AnimalsRepository>();
        return services;
    }
    
}