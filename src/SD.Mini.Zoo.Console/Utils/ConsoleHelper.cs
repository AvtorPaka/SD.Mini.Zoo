using SD.Mini.Zoo.Console.Enums;

namespace SD.Mini.Zoo.Console.Utils;

internal static class ConsoleHelper
{
    private static readonly string Delimiter = new string('-', 30);

    internal static void PrintMenu()
    {
        System.Console.WriteLine(
            $"\nMenu\n{Delimiter}\n[1]. Add new animal to the zoo\n[2]. Get list of animals\n[3]. Get list of contact animals\n[4]. Get daily food consumption\n[5]. Exit\n{Delimiter}");
    }

    internal static int ReadKeyInRange(int minRange = 1, int maxRange = 5)
    {
        var keyInfo = System.Console.ReadKey(true);
        while (int.Parse(keyInfo.KeyChar.ToString()) < minRange || int.Parse(keyInfo.KeyChar.ToString()) > maxRange)
        {
            keyInfo = System.Console.ReadKey(true);
        }

        return int.Parse(keyInfo.KeyChar.ToString());
    }

    internal static int ReadInt()
    {
        int value = 0;
        bool state = int.TryParse(System.Console.ReadLine(), out value);
        while (!state)
        {
            state = int.TryParse(System.Console.ReadLine(), out value);
        }

        return value;
    }
    
    internal static double ReadDouble()
    {
        double value = 0d;
        bool state = double.TryParse(System.Console.ReadLine(), out value);
        while (!state)
        {
            state = double.TryParse(System.Console.ReadLine(), out value);
        }

        return value;
    }

    internal static void PrintAnimalSpecies()
    {
        foreach (AnimalSpecies spec in Enum.GetValues<AnimalSpecies>())
        {
            System.Console.WriteLine($"[{(int)spec}]. {spec}");
        }
    }
}