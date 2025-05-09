// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var data = GetDataFromFile();
List<int> possibleGameNumbers = new List<int>();

foreach(string line in data)
{
    if(IsGamePossible(line))
    {
        string gameNumber = line.Split(':')[0].Trim();
        possibleGameNumbers.Add(int.Parse(gameNumber.Split(' ')[1]));

        Console.WriteLine($"{line} is possible.");
    }
}

Console.WriteLine("La somme des numéros de jeux possibles est : " + possibleGameNumbers.Sum());

bool IsGamePossible(string game)
{
    string drawsRaw = game.Split(':')[1].Trim();
    string[] draws = drawsRaw.Split(';');

    foreach(string draw in draws)
    {
        if(!IsDrawPossible(draw.Trim()))
        {
            return false;
        }
    }

    return true;
}

bool IsDrawPossible(string draw)
{
    int maxRedCubes = 12;
    int maxGreenCubes = 13;
    int maxBlueCubes = 14;

    int countRedCubes = 0;
    int countGreenCubes = 0;
    int countBlueCubes = 0;

    string[] parts = draw.Split(',');

    foreach(string part in parts)
    {
        string[] colorAndCount = part.Trim().Split(' ');
        string color = colorAndCount[1].Trim();
        int count = int.Parse(colorAndCount[0].Trim());

        if(color == "red")
        {
            countRedCubes += count;
        }
        else if(color == "green")
        {
            countGreenCubes += count;
        }
        else if(color == "blue")
        {
            countBlueCubes += count;
        }
    }

    return countRedCubes <= maxRedCubes && countGreenCubes <= maxGreenCubes && countBlueCubes <= maxBlueCubes;
}

List<string> GetDataFromFile()
{
    // Allow to read from the data.txt file
    // and return the data as a list of strings.

    string filePath = "data.txt";
    List<string> data = new List<string>();

    using(StreamReader sr = new StreamReader(filePath))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            data.Add(line);
        }
    }

    return data;
}