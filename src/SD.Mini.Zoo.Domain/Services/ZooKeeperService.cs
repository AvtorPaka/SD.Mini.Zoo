using SD.Mini.Zoo.Domain.Contracts.Dal.Interfaces;
using SD.Mini.Zoo.Domain.Exceptions;
using SD.Mini.Zoo.Domain.Models.Base;
using SD.Mini.Zoo.Domain.Services.Interfaces;

namespace SD.Mini.Zoo.Domain.Services;

public class ZooKeeperService: IZooKeeperService
{
    private readonly IAnimalVetService _animalVetService;
    private readonly IAnimalsRepository _animalsRepository;

    public ZooKeeperService(IAnimalVetService animalVetService, IAnimalsRepository animalsRepository)
    {
        _animalVetService = animalVetService;
        _animalsRepository = animalsRepository;
    }

    public void AddNewAnimal(Animal animalModel)
    {
        try
        {
            AddNewAnimalUnsafe(animalModel);
        }
        catch (AnimalValidationException ex)
        {
            Console.WriteLine($"\nAnimal could not be added to the zoo.\n{ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{DateTime.Now} | Unexpected exception occured during AddAnimal call.\n{ex.Message}");
        }
    }
    
    private void AddNewAnimalUnsafe(Animal animalModel)
    {
        if (!_animalVetService.ValidateAnimalHealth(animalModel))
        {
            throw new AnimalValidationException("Invalid animal. Animal is sick.");
        }
        _animalsRepository.AddAnimal(animalModel);
    }

    public IReadOnlyList<Animal> GetAllAnimals()
    {
        try
        {
            return GetAllAnimalsUnsafe();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{DateTime.Now} | Unexpected exception occured during animals querying.\n{ex.Message}");
            throw;
        }
    }

    private IReadOnlyList<Animal> GetAllAnimalsUnsafe()
    {
        return _animalsRepository.QueryAnimals();
    }

    public double GetTotalDailyFoodConsumption()
    {
        try
        {
            return GetTotalDailyFoodConsumptionUnsafe();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{DateTime.Now} | Unexpected exception occured during total food consumption calculation.\n{ex.Message}");
            throw;
        }
    }

    private double GetTotalDailyFoodConsumptionUnsafe()
    {
        var animals = _animalsRepository.QueryAnimals();
        return animals.Count == 0 ? 0 : animals.Sum(m => m.Food);
    }

    public IReadOnlyList<Animal> GetAllContactAnimals()
    {
        try
        {
            return GetAllContactAnimalsUnsafe();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{DateTime.Now} | Unexpected exception occured during contact animals querying.\n{ex.Message}");
            throw;
        }
    }
    
    private IReadOnlyList<Animal> GetAllContactAnimalsUnsafe()
    {
        return _animalsRepository.QueryAnimals().Where(m => m is Herbivore herbivore && herbivore.IsContact()).ToList();
    }
}