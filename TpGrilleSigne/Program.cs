// Lecture des données du fichier data.txt
using System.Drawing;
using TpGrilleSigne.Models;

var data = GetDataFromFile();
var gridNumbers = new List<GridNumber>();
var symbolsCoordinates = new List<Point>();

for(int y = 0; y < data.Count; y++)
{
    GridNumber currentGridNumber = null;

    for(int x = 0; x < data[y].Length; x++)
    {
        char currentChar = data[y][x];

        if (char.IsDigit(currentChar))
        {
            if(currentGridNumber == null)
            {
                currentGridNumber = new GridNumber();
                currentGridNumber.StringerNumber = currentChar.ToString();
                currentGridNumber.AddNearestCoordinates(x, y);
            }
            else
            {
                currentGridNumber.StringerNumber += currentChar.ToString();
                currentGridNumber.AddNearestCoordinates(x, y);
            }

            if (x == data[y].Length - 1)
            {
                gridNumbers.Add(currentGridNumber);
                currentGridNumber = null;
            }
        }
        else 
        {
            if (currentChar != '.')
            {
                symbolsCoordinates.Add(new Point(x, y));
            }
            
            if(currentGridNumber != null)
            {
                gridNumbers.Add(currentGridNumber);
                currentGridNumber = null;
            }
        }
    }
}

int sumOfNumberNotTouchingSymbols = 0;
List<GridNumber> gridNumbersNotTouchingSymbols = new List<GridNumber>();

foreach(var gridNumber in gridNumbers)
{
    bool isTouching = false;

    foreach(var symbolCoordinate in symbolsCoordinates)
    {
        if (gridNumber.NearestCoordinates.Contains(symbolCoordinate))
        {
            isTouching = true;
            break;
        }
    }

    if (!isTouching)
    {
        gridNumbersNotTouchingSymbols.Add(gridNumber);
        sumOfNumberNotTouchingSymbols += gridNumber.Number;
        Console.WriteLine("Number not touching symbols: " + gridNumber.StringerNumber);
    }
}


Console.WriteLine("Sum of numbers not touching symbols: " + sumOfNumberNotTouchingSymbols);
Console.WriteLine("There are " + gridNumbersNotTouchingSymbols.Count + " numbers not touching symbols.");












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