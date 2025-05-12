using System.Text.Json.Serialization;

namespace PersonManagerWinForm.Models
{
    internal class Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}
