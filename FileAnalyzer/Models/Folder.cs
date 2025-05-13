namespace FileAnalyzer.Models;

public class Folder
{
    public string Name { get; set; }
    public List<Folder> SubFolders {get; set; } = new List<Folder>();
    public Folder ParentFolder { get; set; }
    public Dictionary<string, int> Files { get; set; } = new Dictionary<string, int>();
    public int FolderSize => Files.Sum(f => f.Value);
    public int TotalSize => FolderSize + SubFolders.Sum(f => f.TotalSize);

    public Folder(string name)
    {
        Name = name;
    }
}