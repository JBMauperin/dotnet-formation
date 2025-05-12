namespace Common
{
    public static class FileReader
    {
        public static List<string> ReadLines(string filePath)
        {
            return File.ReadAllLines(filePath).ToList();
        }
    }
}
