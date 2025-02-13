using SD.Mini.Zoo.Domain.Models.Base;

namespace SD.Mini.Zoo.Domain.Models.Animals;

public class Rabbit: Herbivore
{
    public Rabbit(string name, double consumption, int kindness) : base(name, "Rabbit", consumption, kindness)
    {
    }
}