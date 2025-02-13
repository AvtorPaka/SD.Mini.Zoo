namespace SD.Mini.Zoo.Domain.Models.Base;

public abstract class Predator: Animal
{
    protected Predator(string name, string spec, double consumption) : base(name, spec, consumption)
    {
    }
    
    public override string ToString()
    {
        return $"Type: Predator\nAnimal species : {Species}\nAnimal name: {Nickname}\nDaily food consumption: {Food} kg\nStorageId : {Number}";
    }
}