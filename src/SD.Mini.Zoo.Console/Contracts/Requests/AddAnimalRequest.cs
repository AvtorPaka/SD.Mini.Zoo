using SD.Mini.Zoo.Console.Enums;

namespace SD.Mini.Zoo.Console.Contracts.Requests;

public record AddAnimalRequest(
    string Nickname,
    AnimalSpecies Species,
    double FoodConsumption,
    int Kindness
);