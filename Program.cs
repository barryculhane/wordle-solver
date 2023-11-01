
Console.Clear();
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("WORDLE SOLVER");
Console.WriteLine();

var input = string.Empty;

do
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("Enter a 5-character puzzle> ");
    Console.ResetColor();

    input = Console.ReadLine()?.ToUpper();

    if (input != null)
    {
        if (input.Equals("EXIT"))
        {
            goto AppExit;
        }

        if (!input.Length.Equals(5))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Puzzle must be 5 characters!");
            Console.ResetColor();
        }

        break;
    }
}
while (true);

var combinations = new List<string>();
var word = string.Empty;

for (var letter1number = 65; letter1number < 90; letter1number++)
{
    var character1 = char.IsLetter(input[0]) ? input[0] : (char)letter1number;

    for (var letter2number = 65; letter2number < 90; letter2number++)
    {
        var character2 = char.IsLetter(input[1]) ? input[1] : (char)letter2number;

        for (var letter3number = 65; letter3number < 90; letter3number++)
        {
            var character3 = char.IsLetter(input[2]) ? input[2] : (char)letter3number;

            for (var letter4number = 65; letter4number < 90; letter4number++)
            {
                var character4 = char.IsLetter(input[3]) ? input[3] : (char)letter4number;

                for (var letter5number = 65; letter5number < 90; letter5number++)
                {
                    var character5 = char.IsLetter(input[4]) ? input[4] : (char)letter5number;

                    word = $"{character1}{character2}{character3}{character4}{character5}";

                    combinations.Add(word);

                    if (char.IsLetter(input[4]))
                    {
                        break;
                    }
                }

                if (char.IsLetter(input[3]))
                {
                    break;
                }
            }

            if (char.IsLetter(input[2]))
            {
                break;
            }
        }

        if (char.IsLetter(input[1]))
        {
            break;
        }
    }

    if (char.IsLetter(input[0]))
    {
        break;
    }
}

foreach (var combination in combinations)
{
    var definitions = gnuciDictionary.EnglishDictionary.Define(combination);

    if (definitions?.Any() ?? false)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine();
        Console.WriteLine(combination);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(definitions.First().Definition);
        Console.ResetColor();
    }
}

if (combinations.Count.Equals(0))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"No solutions found for '{input}'");
    Console.ResetColor();
}

AppExit:
Console.WriteLine();