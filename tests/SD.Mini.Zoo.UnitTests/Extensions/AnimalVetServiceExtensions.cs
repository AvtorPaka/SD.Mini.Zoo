using Moq;
using SD.Mini.Zoo.Domain.Models.Base;
using SD.Mini.Zoo.Domain.Services.Interfaces;

namespace SD.Mini.Zoo.UnitTests.Extensions;

public static class AnimalVetServiceExtensions
{
    public static Mock<IAnimalVetService> SetupValidateAnimalHealth(this Mock<IAnimalVetService> mock, bool state)
    {
        mock.Setup(m =>
            m.ValidateAnimalHealth(
                It.IsAny<Animal>())
        ).Returns(state);

        return mock;
    }

    public static Mock<IAnimalVetService> VerifyValidateAnimalHealthWasCalledOnce(this Mock<IAnimalVetService> mock)
    {
        mock.Verify(m =>
                m.ValidateAnimalHealth(
                    It.IsAny<Animal>()),
                    Times.Once());

        return mock;
    }
}