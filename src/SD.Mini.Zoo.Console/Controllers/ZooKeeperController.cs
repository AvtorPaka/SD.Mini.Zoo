using SD.Mini.Zoo.Console.Contracts.Requests;
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
        
    }

    public void GetAnimalsInfo()
    {
        
    }

    public void GetTotalFoodConsumption()
    {
        
    }
    
    public void GetContactAnimals()
    {
        
    }
}