using PersonManagerWinForm.Models;
using System.Text.Json;

namespace PersonManagerWinForm.Repositories
{
    internal class FilePersonRepository
    {
        string _filePath = "database.json";
        public void SavePerson(Person person)
        {
            var persons = ReadAllPersonFromFile();
            persons.Add(person);
            WriteAllPersonToFile(persons);
        }

        public List<Person> ReadAllPersonFromFile()
        {
            List<Person> persons = new List<Person>();

            if (!File.Exists(_filePath))
            {
                return persons;
            }

            string fileContent = File.ReadAllText(_filePath);

            if (string.IsNullOrEmpty(fileContent))
            {
                return persons;
            }

            persons = JsonSerializer.Deserialize<List<Person>>(fileContent);

            return persons.OrderBy(p => p.LastName).ToList();
        }

        public void WriteAllPersonToFile(List<Person> persons)
        {
            string json = JsonSerializer.Serialize(persons);
            File.WriteAllText(_filePath, json);
        }
    }
}
