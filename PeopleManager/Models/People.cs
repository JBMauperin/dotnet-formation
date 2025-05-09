using System.Data.Common;

namespace PeopleManager.Models
{
    public class People
    {
        public int Id { get; set; }
        private string _name;
        public string Name { 
            get
            {
                return _name;
            } 
            set
            {
                _name = value.ToUpper();
            } 
        }
        private string _firstName;
        public string FirstName { 
            get
            {
                return _firstName;
            } 
            set
            {
                _firstName = value[0].ToString().ToUpper() + value.Substring(1).ToLower();
            } 
        }
        public string FullName 
        { 
            get
            {
                return $"{FirstName} {Name}";
            }
        }
        public int Age { get; set; }

        public People()
        {
            
        }

        public People(int id, string name, string firstName, int age)
        {
            Id = id;
            Name = name;
            FirstName = firstName;
            Age = age;
        }

        public override string ToString()
        {
            return $"Id : {Id} -  Nom : {Name}, Prénom : {FirstName}, Age : {Age}";
        }
    }        
}
