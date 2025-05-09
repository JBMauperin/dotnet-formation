using PeopleManager.Models;

namespace PeopleManager.Services
{
    public class PeopleService
    {
        List<People> peoples = new List<People>();

        /// <summary>
        /// Permet d'ajouter une personne à la liste
        /// </summary>
        /// <param name="name"></param>
        /// <param name="firstName"></param>
        /// <param name="age"></param>
        public People AddPeople(string name, string firstName, int age)
        {
            peoples.Add(new People(peoples.Count + 1, name, firstName, age));
            return peoples.Last();
        }
        
        public List<People> GetAllPeople()
        {
            return peoples;
        }

        public List<People> GetAllPeople(string search)
        {
            return peoples.Where(p => p.Name.ToLower().Contains(search.ToLower()) || p.FirstName.ToLower().Contains(search.ToLower()) || p.Age.ToString().Contains(search)).ToList();
        }

        public void ModifyPeople(int selectedPersonId, string name, string firstName, int age)
        {
            var peopleToModify = peoples.FirstOrDefault(p => p.Id == selectedPersonId);

            if(peopleToModify != null)
            {
                peopleToModify.Name = name;
                peopleToModify.FirstName = firstName;
                peopleToModify.Age = age;
            }
        }

        public void DeletePeople(int peopleToDeleteId)
        {
            if(peoples.Any(p => p.Id == peopleToDeleteId))
            {
                peoples.RemoveAt(peopleToDeleteId - 1);
            }
        }
    }
}