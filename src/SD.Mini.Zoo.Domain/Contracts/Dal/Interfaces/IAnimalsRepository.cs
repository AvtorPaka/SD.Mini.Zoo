using SD.Mini.Zoo.Domain.Models.Base;

namespace SD.Mini.Zoo.Domain.Contracts.Dal.Interfaces;

public interface IAnimalsRepository
{
    public void AddAnimal(Animal animalModel);

    public IReadOnlyList<Animal> QueryAnimals();
}