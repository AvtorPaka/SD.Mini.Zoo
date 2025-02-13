using System.Text;
using SD.Mini.Zoo.Console.Contracts.Requests;
using SD.Mini.Zoo.Console.Mappers;
using SD.Mini.Zoo.Domain.Models.Base;
using SD.Mini.Zoo.Domain.Services.Interfaces;

namespace SD.Mini.Zoo.Console.Controllers;

public sealed class ZooKeeperController
{
    private readonly IZooKeeperService _zooKeeperService;

    public ZooKeeperController(IZooKeeperService zooKeeperService)
    {
        _zooKeeperService = zooKeeperService;
    }

    public void AddAnimal(AddAnimalRequest request)
    {
        var model = request.MapRequestToModel();
        _zooKeeperService.AddNewAnimal(
            animalModel: model
        );
        System.Console.WriteLine($"\nAdded animal:\n{model}");
    }

    public void GetAnimalsInfo()
    {
        var animals = _zooKeeperService.GetAllAnimals();
        System.Console.WriteLine(
            $"\nAnimals amount {animals.Count}\n{GetAnimalsString(animals)}");
    }

    public void GetTotalFoodConsumption()
    {
        double totalFoodConsumption = _zooKeeperService.GetTotalDailyFoodConsumption();
        System.Console.WriteLine(
            $"\nAnimals daily food consumption: {totalFoodConsumption} kg.");
    }

    public void GetContactAnimals()
    {
        var contactAnimals = _zooKeeperService.GetAllContactAnimals();
        System.Console.WriteLine(
            $"\nContact animals amount {contactAnimals.Count}\n{GetAnimalsString(contactAnimals)}");
    }

    private static string GetAnimalsString(IReadOnlyList<Animal> animals)
    {
        if (animals.Count == 0)
        {
            return "Zoo doesnt contains such animals.";
        }

        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < animals.Count; ++i)
        {
            builder.Append($"\n{animals[i]}\n");
        }

        return builder.ToString();
    }
}