using System.Text.RegularExpressions;
using FileAnalyzer.Models;

var data = File.ReadAllLines("data.txt").ToList();
data.RemoveAt(0);

Folder rootFolder = new Folder("/");
Folder currentFolder = rootFolder;

foreach (var line in data)
{
    if (line.StartsWith("$ cd"))
    {
        var parts = line.Split(" ");
        var folderName = parts[2];

        if (folderName == "..")
        {
            currentFolder = currentFolder.ParentFolder;
        }
        else
        {
            if(!currentFolder.SubFolders.Any(f => f.Name == folderName))
            {
                var newFolder = new Folder(folderName)
                {
                    ParentFolder = currentFolder
                };
                currentFolder.SubFolders.Add(newFolder);
                currentFolder = newFolder;
            }
            else
            {
                currentFolder = currentFolder.SubFolders.First(f => f.Name == folderName);
            }
        }
    }
    else if (Regex.IsMatch(line, @"^\d+"))
    {
        currentFolder.Files.Add(line.Split(" ")[1], int.Parse(line.Split(" ")[0]));
    }
}

//Part 1
int sumOfLTE100k = 0;
int countOfFolders = 0;

Console.WriteLine("Sum of folders with size <= 100k: " + FindLTE100kFolders(rootFolder, sumOfLTE100k));
Console.WriteLine("Count of folders with size <= 100k: " + countOfFolders);

// Part 2
int totalDiskSpace = 70000000;
int requiredSpace = 30000000;
int neededSpace = requiredSpace - (totalDiskSpace - rootFolder.TotalSize);

Console.WriteLine("Total size of root folder: " + rootFolder.TotalSize);
Console.WriteLine("Space to free: " + neededSpace);

Folder folderToDelete = null;
FindSmallestFolderToDelete(rootFolder);

Console.WriteLine($"Folder to delete: {folderToDelete.Name}, Size: {folderToDelete.TotalSize}");

int FindLTE100kFolders(Folder folder, int sum)
{
    if (folder.TotalSize <= 100000)
    {
        sum += folder.TotalSize;
        countOfFolders++;
        Console.WriteLine($"Folder: {folder.Name}, Size: {folder.TotalSize}");
    }

    foreach (var subFolder in folder.SubFolders)
    {
        sum = FindLTE100kFolders(subFolder, sum);
    }

    return sum;
}

void FindSmallestFolderToDelete(Folder folder)
{
    if(folder.TotalSize >= neededSpace && (folderToDelete == null || folderToDelete.TotalSize > folder.TotalSize))
    {
        folderToDelete = folder;
    }

    foreach (var subFolder in folder.SubFolders)
    {
        FindSmallestFolderToDelete(subFolder);
    }
}