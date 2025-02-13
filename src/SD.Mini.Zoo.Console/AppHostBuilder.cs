using Microsoft.Extensions.DependencyInjection;

namespace SD.Mini.Zoo.Console;

internal sealed class AppHostBuilder
{
    private readonly IServiceCollection? _serviceCollection;

    private AppHostBuilder()
    {
        _serviceCollection = new ServiceCollection();
    }

    internal void ConfigureServices(Action<IServiceCollection>? servicesConfigureAction = null)
    {
        ArgumentNullException.ThrowIfNull(_serviceCollection, nameof(_serviceCollection));
        ArgumentNullException.ThrowIfNull(servicesConfigureAction, nameof(servicesConfigureAction));
        servicesConfigureAction(_serviceCollection);
    }

    internal App Build()
    {
        ArgumentNullException.ThrowIfNull(_serviceCollection, nameof(_serviceCollection));
        return new App(_serviceCollection.BuildServiceProvider());
    }

    internal static AppHostBuilder CreateDefaultBuilder()
    {
        return new AppHostBuilder();
    }
}