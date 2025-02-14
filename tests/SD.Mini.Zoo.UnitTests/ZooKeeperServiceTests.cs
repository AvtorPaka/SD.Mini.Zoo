using SD.Mini.Zoo.Domain.Exceptions;
using SD.Mini.Zoo.Domain.Models.Animals;
using SD.Mini.Zoo.Domain.Models.Base;
using SD.Mini.Zoo.UnitTests.Builders;
using SD.Mini.Zoo.UnitTests.Extensions;

namespace SD.Mini.Zoo.UnitTests;

public class ZooKeeperServiceTests
{
    [Theory]
    [InlineData(0)]
    public void GetTotalDailyFoodConsumption_ContainingZeroAnimals_ReturnZero(double expected)
    {
        // Arrange
        var builder = new ZooKeeperServiceBuilder();

        builder.AnimalsRepository
            .SetupEmptyQueryAnimals();

        var cut = builder.Build();
        
        // Act
        var result = cut.GetTotalDailyFoodConsumption();
        
        
        //Assert
        Assert.Equal(result, expected);

        cut.AnimalsRepository
            .VerifyQueryAnimalWasCalledOnce();
        
        cut.VerifyNoOtherCalls();
    }

    [Theory]
    [MemberData(nameof(GetTotalDailyFoodConsumptionMemberData))]
    public void GetTotalDailyFoodConsumption_ContainingAnimals_Success(IReadOnlyList<Animal> animalsList, double expected)
    {
        // Arrange
        var builder = new ZooKeeperServiceBuilder();

        builder.AnimalsRepository
            .SetupContainingQueryAnimals(animalsList);

        var cut = builder.Build();
        
        // Act
        var result = cut.GetTotalDailyFoodConsumption();
        
        
        //Assert
        Assert.Equal(result, expected);

        cut.AnimalsRepository
            .VerifyQueryAnimalWasCalledOnce();
        
        cut.VerifyNoOtherCalls();
    }

    [Fact]
    public void AddNewAnimal_PassingValidAnimal_Success()
    {
        // Arrange
        var builder = new ZooKeeperServiceBuilder();

        builder.AnimalsRepository
            .SetupAddAnimal();

        builder.AnimalVetService
            .SetupValidateAnimalHealth(true);

        var cut = builder.Build();

        Animal testAnimal = new Monkey("test", 10, 10);
        // Act
        cut.AddNewAnimal(testAnimal);
        
        //Assert
        cut.AnimalsRepository
            .VerifyAddAnimalWasCalledOnce();

        cut.AnimalVetService
            .VerifyValidateAnimalHealthWasCalledOnce();
        
        cut.VerifyNoOtherCalls();
    }
    
    [Fact]
    public void AddNewAnimal_PassingInvalidAnimal_ThrowsAnimalValidationException()
    {
        // Arrange
        var builder = new ZooKeeperServiceBuilder();
        
        builder.AnimalVetService
            .SetupValidateAnimalHealth(false);

        var cut = builder.Build();

        Animal testAnimal = new Monkey("test", 10, 10);
        
        //Assert
        Assert.Throws<AnimalValidationException>(() => cut.AddNewAnimal(testAnimal));
        
        cut.AnimalVetService
            .VerifyValidateAnimalHealthWasCalledOnce();
        
        cut.VerifyNoOtherCalls();
    }

    [Theory]
    [MemberData(nameof(GetAllContactAnimalsMemberData))]
    public void GetAllContactAnimals_DifferentAnimalsMembers_CountShouldEqualsExpected(IReadOnlyList<Animal> testAnimals, int expected)
    {
        // Arrange
        var builder = new ZooKeeperServiceBuilder();

        builder.AnimalsRepository
            .SetupContainingQueryAnimals(testAnimals);
        
        var cut = builder.Build();
        
        // Act
        var result = cut.GetAllContactAnimals();
        
        //Assert
        Assert.Equal(result.Count, expected);
        
        cut.AnimalsRepository
            .VerifyQueryAnimalWasCalledOnce();
        
        cut.VerifyNoOtherCalls();
    }
    
    [Fact]
    public void GetAllAnimalsUnsafe_QueryAnimalsWasCalledOnce_Success()
    {
        // Arrange
        var builder = new ZooKeeperServiceBuilder();

        builder.AnimalsRepository
            .SetupEmptyQueryAnimals();
        var cut = builder.Build();

        // Act
        var result = cut.GetAllAnimals();
        
        //Assert
        cut.AnimalsRepository
            .VerifyQueryAnimalWasCalledOnce();

        
        cut.VerifyNoOtherCalls();
    }

    public static IEnumerable<object[]> GetAllContactAnimalsMemberData
    {
        get
        {
            yield return new object[]
            {
                new List<Animal>
                {
                    new Monkey(
                        name: "testName",
                        consumption: 10,
                        kindness: 10)
                },
                1
            };
            
            yield return new object[]
            {
                new List<Animal>
                {
                    new Wolf(
                        name: "testName",
                        consumption: 7),
                    new Tiger(
                        name: "testNameSec",
                        consumption: 11),
                    new Tiger(
                        name: "testNameTh",
                        consumption: 0.33),
                    new Rabbit(
                        name: "testNameFr",
                        consumption: 555,
                        kindness: 2),
                    new Rabbit(
                        name: "testNameFif",
                        consumption: 300,
                        kindness: 5),
                },
                0
            };
            
            yield return new object[]
            {
                new List<Animal>
                {
                    new Wolf(
                        name: "testName",
                        consumption: 7),
                    new Rabbit(
                        name: "testNameFr",
                        consumption: 555,
                        kindness: 6),
                    new Rabbit(
                        name: "testNameFif",
                        consumption: 300,
                        kindness: 10),
                    new Rabbit(
                        name: "testNameAga",
                        consumption: 15,
                        kindness: 3),
                    new Rabbit(
                        name: "testNameUgu",
                        consumption: 3,
                        kindness: 7)
                },
                3
            };
        }
    }
    
    public static IEnumerable<object[]> GetTotalDailyFoodConsumptionMemberData
    {
        get
        {
            yield return new object[]
            {
                new List<Animal>
                {
                    new Monkey(
                        name: "testName",
                        consumption: 10,
                        kindness: 10)
                },
                10
            };
            
            yield return new object[]
            {
                new List<Animal>
                {
                    new Wolf(
                        name: "testName",
                        consumption: 5.55),
                    new Tiger(
                        name: "testNameSec",
                        consumption: 112),
                    new Monkey(
                        name: "testNameTh",
                        consumption: 0.33,
                        kindness: 8),
                    new Rabbit(
                        name: "testNameFr",
                        consumption: 0,
                        kindness: 2),
                },
                117.88
            };
        }
    }
}