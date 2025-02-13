using SD.Mini.Zoo.Domain.Models.Interfaces;

namespace SD.Mini.Zoo.Domain.Models.Base;

public abstract class Animal: IAlive, IInventory
{
    public readonly string Nickname;
    public readonly string Species;
    private readonly double _foodConsumption;
    private readonly Guid _storageId;

    protected Animal(string name, string spec, double consumption)
    {
        Nickname = name;
        Species = spec;
        _foodConsumption = consumption;
        _storageId = Guid.NewGuid();

    }

    public double Food => _foodConsumption;
    public Guid Number => _storageId;
}