using Moq;
using SD.Mini.Zoo.Domain.Contracts.Dal.Interfaces;
using SD.Mini.Zoo.Domain.Services;
using SD.Mini.Zoo.Domain.Services.Interfaces;

namespace SD.Mini.Zoo.UnitTests.Stubs;

public class ZooKeeperServiceStub: ZooKeeperService
{
    public Mock<IAnimalVetService> AnimalVetService { get; init; }
    public Mock<IAnimalsRepository> AnimalsRepository { get; init; }
    
    public ZooKeeperServiceStub(
        Mock<IAnimalVetService> animalVetService,
        Mock<IAnimalsRepository> animalsRepository)
        : base(animalVetService.Object, animalsRepository.Object)
    {
        AnimalVetService = animalVetService;
        AnimalsRepository = animalsRepository;
    }

    public void VerifyNoOtherCalls()
    {
        AnimalVetService.VerifyNoOtherCalls();
        AnimalsRepository.VerifyNoOtherCalls();
    }
}