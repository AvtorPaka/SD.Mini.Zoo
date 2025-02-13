using SD.Mini.Zoo.Domain.Models.Base;

namespace SD.Mini.Zoo.Domain.Models.Animals;

public class Tiger: Predator
{
    public Tiger(string name, double consumption) : base(name, "Tiger", consumption)
    {
    }
}