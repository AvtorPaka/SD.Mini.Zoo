using SD.Mini.Zoo.Domain.Models.Base;

namespace SD.Mini.Zoo.Domain.Services.Interfaces;

public interface IAnimalVetService
{
    public bool ValidateAnimalHealth(Animal animalModel);
}