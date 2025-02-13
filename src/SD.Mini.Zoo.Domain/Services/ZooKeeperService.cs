using SD.Mini.Zoo.Domain.Contracts.Dal.Interfaces;
using SD.Mini.Zoo.Domain.Services.Interfaces;

namespace SD.Mini.Zoo.Domain.Services;

public class ZooKeeperService: IZooKeeperService
{
    private readonly IAnimalVetService _animalVetService;
    private readonly IAnimalsRepository _animalsRepository;

    public ZooKeeperService(IAnimalVetService animalVetService, IAnimalsRepository animalsRepository)
    {
        _animalVetService = animalVetService;
        _animalsRepository = animalsRepository;
    }
}