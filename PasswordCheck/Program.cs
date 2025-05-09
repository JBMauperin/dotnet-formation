// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var data = GetDataFromFile();
var validPasswordCount = 0;
var validPasswordCount2 = 0;

foreach(var line in data)
{
    string password = line.Split(':')[1].Trim();
    char requiredChar = line.Split(':')[0].Split(' ')[1][0];
    int firstPosition = int.Parse(line.Split(':')[0].Split(' ')[0].Split('-')[0]);
    int secondPosition = int.Parse(line.Split(':')[0].Split(' ')[0].Split('-')[1]);

    if (IsPasswordValid(requiredChar, firstPosition, secondPosition, password))
    {
        validPasswordCount++;
        Console.WriteLine($"Valid password: {line}");
    }

    if (IsPasswordValid2(requiredChar, firstPosition, secondPosition, password))
    {
        validPasswordCount2++;
        Console.WriteLine($"Valid password 2: {line}");
    }
}

Console.WriteLine($"Total valid passwords: {validPasswordCount}");
Console.WriteLine($"Total valid passwords 2: {validPasswordCount2}");

bool IsPasswordValid(char requiredChar, int firstPosition, int secondPosition, string passwordToTest)
{
    return (passwordToTest[firstPosition - 1] == requiredChar) || (passwordToTest[secondPosition - 1] == requiredChar);
}

bool IsPasswordValid2(char requiredChar, int minQuantity, int maxQuantity, string passwordToTest)
{
    int charCount = 0;
    foreach (char c in passwordToTest)
    {
        if (c == requiredChar)
        {
            charCount++;
        }
    }

    return (charCount >= minQuantity && charCount <= maxQuantity);
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