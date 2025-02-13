using Microsoft.Extensions.DependencyInjection;
using SD.Mini.Zoo.Console.Contracts.Requests;
using SD.Mini.Zoo.Console.Controllers;

namespace SD.Mini.Zoo.Console;

using System;

internal sealed class App
{
    private readonly IServiceProvider _serviceProvider;

    internal App(IServiceProvider provider)
    {
        _serviceProvider = provider;
    }

    internal void Run()
    {
        Console.WriteLine($"{DateTime.Now} | Zoo app started executing");
        HandleRequests();
        Console.WriteLine($"{DateTime.Now} | Zoo app stopped executing");
    }

    /// <summary>
    /// Imitation of requests handling
    /// </summary>
    private void HandleRequests()
    {
        ZooKeeperController controller = _serviceProvider.GetRequiredService<ZooKeeperController>();
        controller.AddAnimal(new AddAnimalRequest());
    }
}