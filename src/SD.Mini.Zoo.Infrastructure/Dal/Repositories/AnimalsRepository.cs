using SD.Mini.Zoo.Domain.Contracts.Dal.Interfaces;
using SD.Mini.Zoo.Domain.Models.Base;

namespace SD.Mini.Zoo.Infrastructure.Dal.Repositories;

public class AnimalsRepository: IAnimalsRepository
{
    private readonly List<Animal> _animalsStorage = new List<Animal>();
    
    public void AddAnimal(Animal animalModel)
    {
        _animalsStorage.Add(animalModel);
    }

    public IReadOnlyList<Animal> QueryAnimals()
    {
        return _animalsStorage;
    }
}