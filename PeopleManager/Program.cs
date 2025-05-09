// See https://aka.ms/new-console-template for more information

using PeopleManager.Models;
using PeopleManager.Services;
using System.Net.Security;
using System.Runtime.CompilerServices;

var userChoice = 0;
PeopleService peopleService = new PeopleService();

do 
{
    Console.WriteLine("Bienvenue dans le plus beau gestionnaire de personnes !");
    Console.WriteLine("1 - Liste des personnes");
    Console.WriteLine("2 - Ajouter une personne");
    Console.WriteLine("3 - Modifier une personne");
    Console.WriteLine("4 - Supprimer une personne");
    Console.WriteLine("5 - Rechercher une personne");
    Console.WriteLine("6 - Quitter");

    userChoice = int.Parse(Console.ReadLine());

    switch (userChoice)
    {
        case 1:
            ListPeopleProcess();
            break;
        case 2:
            AddNewPersonProcess();
            break;
        case 3:
            ModifyPeopleProcess();
            break;
        case 4:
            DeletePeopleProcess();
            break;
        case 5:
            SearchPeopleProcess();
            break;
    }
}
while(userChoice != 6);

void AddNewPersonProcess()
{
    Console.Clear();
    Console.WriteLine("Veuillez entrer le nom de la personne :");
    var name = Console.ReadLine();
    Console.WriteLine("Veuillez entrer le prénom de la personne :");
    var firstName = Console.ReadLine();
    
    Console.WriteLine("Veuillez entrer l'age de la personne :");

    int age = 0;
    
    try
    {
        age = int.Parse(Console.ReadLine());
    }
    catch (FormatException)
    {
        Console.WriteLine("L'age doit être un nombre entier.");
        Console.WriteLine("Merci de réessayer.");
        return;
    }

    var addedPeople = peopleService.AddPeople(name, firstName, age);
    Console.WriteLine($"La personne a été ajoutée et possède l'id {addedPeople.Id}");
}

void ListPeopleProcess()
{
    List<People> peoples = peopleService.GetAllPeople();

    Console.Clear();

    foreach(var people in peoples)
    {
        Console.WriteLine(people.ToString());
    }

    Console.ReadLine();
}

void ModifyPeopleProcess()
{
    Console.Clear();
    Console.WriteLine("Quelle personne voulez-vous éditer ?");

    ListPeopleProcess();

    int selectedPersonId = 0;

    try
    {
        selectedPersonId = int.Parse(Console.ReadLine());
    }
    catch(FormatException)
    {
        Console.WriteLine("Veuillez recommencer et entrer un chiffre cette fois !");
    }

    Console.WriteLine("Veuillez entrer le nouveau nom");
    string name = Console.ReadLine();

    Console.WriteLine("Veuillez entrer le nouveau prénom");
    string firstName = Console.ReadLine();

    Console.WriteLine("Veuillez entrer le nouvel âge");
    int age = int.Parse(Console.ReadLine());

    peopleService.ModifyPeople(selectedPersonId, name, firstName, age);
}

void DeletePeopleProcess()
{
    Console.Clear();
    Console.WriteLine("Veuillez saisir l'id de la personne à supprimer");
    ListPeopleProcess();

    int peopleToDeleteId = int.Parse(Console.ReadLine());

    peopleService.DeletePeople(peopleToDeleteId);
}

void SearchPeopleProcess()
{
    Console.Clear();

    Console.WriteLine("Veuillez entrer votre recherche : ");
    string search = Console.ReadLine();

    List<People> peoples = peopleService.GetAllPeople(search);

    foreach(People people in peoples)
    {
        Console.WriteLine(people);
    }
    Console.ReadLine();
}