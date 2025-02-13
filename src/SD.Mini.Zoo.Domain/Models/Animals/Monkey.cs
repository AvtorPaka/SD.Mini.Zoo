using SD.Mini.Zoo.Domain.Models.Base;

namespace SD.Mini.Zoo.Domain.Models.Animals;

public class Monkey: Herbivore
{
    public Monkey(string name, double consumption, int kindness) : base(name, "Monkey", consumption, kindness)
    {
    }
}