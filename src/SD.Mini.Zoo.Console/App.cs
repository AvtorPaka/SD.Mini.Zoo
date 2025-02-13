using Microsoft.Extensions.DependencyInjection;
using SD.Mini.Zoo.Console.Contracts.Requests;
using SD.Mini.Zoo.Console.Controllers;
using SD.Mini.Zoo.Console.Enums;
using SD.Mini.Zoo.Console.Utils;

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
    /// Imitation of requests handling by controller
    /// </summary>
    private void HandleRequests()
    {
        while (true)
        {
            ConsoleHelper.PrintMenu();
            ConsoleAction action = ConsoleAction.Exit;
            try
            {
                action = (ConsoleAction)ConsoleHelper.ReadKeyInRange();
                var controller = _serviceProvider.GetRequiredService<ZooKeeperController>();

                switch (action)
                {
                    case ConsoleAction.AddAnimal:
                        HandleAddAnimalAction(controller);
                        break;
                    case ConsoleAction.GetAnimals:
                        controller.GetAnimalsInfo();
                        break;
                    case ConsoleAction.GetContactAnimals:
                        controller.GetContactAnimals();
                        break;
                    case ConsoleAction.GetFoodConsumption:
                        controller.GetTotalFoodConsumption();
                        break;
                    case ConsoleAction.Exit:
                        return;
                    default:
                        throw new ArgumentException("Unsupported console action type");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occured during {action} processing.\n{ex.Message}");
            }
        }
    }

    private void HandleAddAnimalAction(ZooKeeperController controller)
    {
        Console.WriteLine(">>Input animal name:");
        string animalName = Console.ReadLine() ?? throw new ArgumentException("Incorrect animal name");
        if (animalName.Length == 0)
        {
            throw new ArgumentException("Animal name could not be empty.");
        }
        Console.WriteLine(">>Choose animal species:");
        ConsoleHelper.PrintAnimalSpecies();
        AnimalSpecies spec = (AnimalSpecies)ConsoleHelper.ReadKeyInRange(1, 4);

        int kindness = 0;
        if (spec == AnimalSpecies.Monkey || spec == AnimalSpecies.Rabbit)
        {
            Console.WriteLine(">>Input animal kindness [0-10]:");
            kindness = ConsoleHelper.ReadInt();
        }

        Console.WriteLine(">>Input animal daily food consumption:");
        double foodConsumption = ConsoleHelper.ReadDouble();

        controller.AddAnimal(
            request: new AddAnimalRequest(
                animalName,
                spec,
                foodConsumption,
                kindness
            )
        );
    }
}