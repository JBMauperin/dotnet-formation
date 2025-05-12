List<string> movesData = File.ReadAllLines("Moves.txt").ToList();

List<List<string>> stacksOfCrates = new List<List<string>>()
{
    new List<string>() { "J", "H", "P", "M", "S", "F", "N", "V" },
    new List<string>() { "S", "R", "L", "M", "J", "D", "Q" },
    new List<string>() { "N", "Q", "D", "H", "c", "S", "W", "B" },
    new List<string>() { "R", "S", "C", "L" },
    new List<string>() { "M", "V", "T", "P", "F", "B" },
    new List<string>() { "T", "R", "Q", "N", "C" },
    new List<string>() { "R", "V", "G" },
    new List<string>() { "C", "Z", "S", "P", "D", "L", "R" },
    new List<string>() { "D", "S", "J", "V", "G", "P", "B", "F" }
};

foreach(string move in movesData)
{
    string[] moveParts = move.Split(' ');
    
    int quantity = int.Parse(moveParts[1]);
    int fromStackNumber = int.Parse(moveParts[3]);
    int toStackNumber = int.Parse(moveParts[5]);

    stacksOfCrates[toStackNumber - 1].AddRange(stacksOfCrates[fromStackNumber - 1].TakeLast(quantity));
    stacksOfCrates[fromStackNumber - 1].RemoveRange(stacksOfCrates[fromStackNumber - 1].Count - quantity, quantity);
}

Console.WriteLine("Final stacks of crates:");
foreach(var stack in stacksOfCrates)
{
    Console.Write(stack.Last());
}
