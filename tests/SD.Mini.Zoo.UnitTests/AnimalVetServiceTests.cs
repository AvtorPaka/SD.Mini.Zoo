using SD.Mini.Zoo.Domain.Models.Animals;
using SD.Mini.Zoo.Domain.Models.Base;
using SD.Mini.Zoo.Domain.Services;

namespace SD.Mini.Zoo.UnitTests;

public class AnimalVetServiceTests
{
    [Theory]
    [MemberData(nameof(ValidateAnimalHealthMemberData))]
    public void ValidateAnimalHealth_DifferentAnimals_ResultShouldEqualsExpected(Animal testAnimal, bool expexcted)
    {
        //Arrange
        var cut = new AnimalVetService();

        //Act
        var result = cut.ValidateAnimalHealth(testAnimal);

        //Assert
        Assert.Equal(result, expexcted);
    }

    public static IEnumerable<object[]> ValidateAnimalHealthMemberData
    {
        get
        {
            yield return new object[]
            {
                new Monkey(
                    name: "Sick animal name",
                    consumption: 10,
                    kindness: 10
                ),
                false
            };
            
            yield return new object[]
            {
                new Wolf(
                    name: "Average animal name",
                    consumption: 1000
                ),
                false
            };
            
            yield return new object[]
            {
                new Wolf(
                    name: "Black Kray a.k.a sick boy rarri",
                    consumption: 1000
                ),
                false
            };
            
            yield return new object[]
            {
                new Wolf(
                    name: "NormalName",
                    consumption: 15.55
                ),
                true
            };
            
        }
    }
}