using SD.Mini.Zoo.Domain.Models.Interfaces;

namespace SD.Mini.Zoo.Domain.Models.Base;

public abstract class Thing: IInventory
{
    private readonly Guid _storageId;

    protected Thing()
    {
        _storageId = Guid.NewGuid();
    }

    public Guid Number => _storageId;
}