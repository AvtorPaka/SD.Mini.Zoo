using SD.Mini.Zoo.Domain.Models.Base;

namespace SD.Mini.Zoo.Domain.Models.Animals;

public class Wolf: Predator
{
    public Wolf(string name, double consumption) : base(name, "Wolf", consumption)
    {
    }
}