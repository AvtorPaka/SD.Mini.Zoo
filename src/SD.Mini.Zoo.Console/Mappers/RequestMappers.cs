using SD.Mini.Zoo.Console.Contracts.Requests;
using SD.Mini.Zoo.Console.Enums;
using SD.Mini.Zoo.Domain.Models.Animals;
using SD.Mini.Zoo.Domain.Models.Base;

namespace SD.Mini.Zoo.Console.Mappers;

internal static class RequestMappers
{
    public static Animal MapRequestToModel(this AddAnimalRequest request)
    {
        Animal model = request.Species switch
        {
            AnimalSpecies.Monkey => new Monkey(ConvertNullString(request.Nickname), request.FoodConsumption, request.Kindness),
            AnimalSpecies.Rabbit => new Rabbit(ConvertNullString(request.Nickname), request.FoodConsumption, request.Kindness),
            AnimalSpecies.Tiger => new Tiger(ConvertNullString(request.Nickname), request.FoodConsumption),
            AnimalSpecies.Wolf => new Wolf(ConvertNullString(request.Nickname), request.FoodConsumption),
            _ => throw new ArgumentException("Unexpected animal species type occured")
        };

        return model;
    }

    private static string ConvertNullString(string? value)
    {
        return value ?? "";
    }
}