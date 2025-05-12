using PersonManagerWinForm.Models;
using PersonManagerWinForm.Repositories;

namespace PersonManagerWinForm.Services
{
    internal class PersonManager
    {
        private FilePersonRepository _filePersonRepository = new FilePersonRepository();

        public Person AddPerson(string lastName, string firstName, string email, int age)
        {
            Person newPerson = new Person
            {
                LastName = lastName,
                FirstName = firstName,
                Email = email,
                Age = age
            };

            _filePersonRepository.SavePerson(newPerson);

            return newPerson;
        }

        public List<Person> GetAllPersons()
        {
            return _filePersonRepository.ReadAllPersonFromFile();
        }

        internal void Delete(string lastName, string firstName)
        {
            var persons = GetAllPersons();

            persons.RemoveAll(p => p.LastName == lastName && p.FirstName == firstName);

            _filePersonRepository.WriteAllPersonToFile(persons);
        }

        internal void EditPerson(Person editedPerson, string lastName, string firstName, string email, int age)
        {
            var persons = GetAllPersons();
            persons.RemoveAll(p => p.LastName == editedPerson.LastName && p.FirstName == editedPerson.FirstName);

            editedPerson.LastName = lastName;
            editedPerson.FirstName = firstName;
            editedPerson.Email = email;
            editedPerson.Age = age;

            persons.Add(editedPerson);
            _filePersonRepository.WriteAllPersonToFile(persons);
        }
    }
}
