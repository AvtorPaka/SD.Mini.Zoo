using SD.Mini.Zoo.Console.Extensions;
using SD.Mini.Zoo.Domain.Extensions;
using SD.Mini.Zoo.Infrastructure.Extensions;

namespace SD.Mini.Zoo.Console;

internal sealed class Program
{
    internal static void Main()
    {
        var appBuilder = AppHostBuilder.CreateDefaultBuilder();
        
        appBuilder.ConfigureServices(services =>
        {
            services
                .AddControllers()
                .AddDomainServices()
                .AddDalRepositories();

        });
        
        appBuilder
            .Build()
            .Run();;
    }
}