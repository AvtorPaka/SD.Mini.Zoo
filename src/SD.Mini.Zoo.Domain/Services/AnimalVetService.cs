using System.Text.RegularExpressions;
using SD.Mini.Zoo.Domain.Models.Base;
using SD.Mini.Zoo.Domain.Services.Interfaces;

namespace SD.Mini.Zoo.Domain.Services;

public class AnimalVetService : IAnimalVetService
{
    public bool ValidateAnimalHealth(Animal animalModel)
    {
        return animalModel.Food < 200 && !ContainsIllegalName(animalModel.Nickname);
    }

    private static bool ContainsIllegalName(string animalName)
    {
        const string substring = "sick";
        string pattern = Regex.Escape(substring);
        var regex = new Regex(pattern, RegexOptions.IgnoreCase);

        return regex.IsMatch(animalName);
    }
}