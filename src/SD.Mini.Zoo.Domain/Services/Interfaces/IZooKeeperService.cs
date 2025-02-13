using SD.Mini.Zoo.Domain.Models.Base;

namespace SD.Mini.Zoo.Domain.Services.Interfaces;

public interface IZooKeeperService
{
    public void AddNewAnimal(Animal animalModel);

    public IReadOnlyList<Animal> GetAllAnimals();

    public double GetTotalDailyFoodConsumption();

    public IReadOnlyList<Animal> GetAllContactAnimals();
}