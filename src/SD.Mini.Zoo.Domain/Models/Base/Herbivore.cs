namespace SD.Mini.Zoo.Domain.Models.Base;

public abstract class Herbivore : Animal
{
    private readonly int _kindness;

    protected Herbivore(string name, string spec, double consumption, int kindness) : base(name, spec, consumption)
    {
        _kindness = (kindness > 10 ? 10 : (kindness < 0 ? 0 : kindness));
    }

    public bool IsContact()
    {
        return _kindness > 5;
    }

    public override string ToString()
    {
        return $"Type: Herbivore\nAnimal species : {Species}\nAnimal name: {Nickname}\nDaily food consumption: {Food} kg\nContact: {(IsContact() ? "Yes" : "No")}\nStorageId : {Number}";
    }
}