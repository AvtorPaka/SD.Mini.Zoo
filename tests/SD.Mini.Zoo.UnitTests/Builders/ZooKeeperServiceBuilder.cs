using Moq;
using SD.Mini.Zoo.Domain.Contracts.Dal.Interfaces;
using SD.Mini.Zoo.Domain.Services.Interfaces;
using SD.Mini.Zoo.UnitTests.Stubs;

namespace SD.Mini.Zoo.UnitTests.Builders;

public class ZooKeeperServiceBuilder
{
    public Mock<IAnimalVetService> AnimalVetService { get; init; }
    public Mock<IAnimalsRepository> AnimalsRepository { get; init; }

    public ZooKeeperServiceBuilder()
    {
        AnimalVetService = new Mock<IAnimalVetService>(MockBehavior.Strict);
        AnimalsRepository = new Mock<IAnimalsRepository>(MockBehavior.Strict);
    }

    public ZooKeeperServiceStub Build()
    {
        return new ZooKeeperServiceStub(
            animalVetService: AnimalVetService,
            animalsRepository: AnimalsRepository
        );
    }
}