using Moq;
using SD.Mini.Zoo.Domain.Contracts.Dal.Interfaces;
using SD.Mini.Zoo.Domain.Models.Base;

namespace SD.Mini.Zoo.UnitTests.Extensions;

public static class AnimalRepositoryExtensions
{
    public static Mock<IAnimalsRepository> SetupAddAnimal(this Mock<IAnimalsRepository> mock)
    {
        mock.Setup(m =>
            m.AddAnimal(
                It.IsAny<Animal>()
            ));

        return mock;
    }

    public static Mock<IAnimalsRepository> SetupEmptyQueryAnimals(this Mock<IAnimalsRepository> mock)
    {
        mock.Setup(m =>
                m.QueryAnimals())
            .Returns(() => []);

        return mock;
    }

    public static Mock<IAnimalsRepository> SetupContainingQueryAnimals(this Mock<IAnimalsRepository> mock,
        IReadOnlyList<Animal> objects)
    {
        mock.Setup(m =>
                m.QueryAnimals())
            .Returns(objects);

        return mock;
    }

    public static Mock<IAnimalsRepository> VerifyAddAnimalWasCalledOnce(this Mock<IAnimalsRepository> mock)
    {
        mock.Verify(m =>
                m.AddAnimal(
                    It.IsAny<Animal>()),
            Times.Once());
        
        return mock;
    }

    public static Mock<IAnimalsRepository> VerifyQueryAnimalWasCalledOnce(this Mock<IAnimalsRepository> mock)
    {
        mock.Verify(m => m.QueryAnimals(), Times.Once);


        return mock;
    }
}