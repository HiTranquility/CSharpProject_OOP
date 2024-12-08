using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Controller
{
    internal class PersonControl<T> where T : Person, new()
    {
        private List<T> personList;
        public List<T> PersonList { get { return personList; } set { this.personList = value; } } 
        public PersonControl() 
        {
            this.personList = new List<T>();
        }
        private string GenerateNextPersonId(string prefix)
        {
            var maxId = personList.Select(p => p.Id)
                                  .Where(id => id.StartsWith(prefix))  
                                  .Select(id =>
                                  {
                                      string numericPart = id.Substring(prefix.Length);
                                      return int.TryParse(numericPart, out var result) ? result : 0;
                                  })
                                  .DefaultIfEmpty(0)
                                  .Max();

            return prefix + (maxId + 1).ToString("D3");
        }
        public virtual void AddPerson(T person)
        {
            if (string.IsNullOrEmpty(person.Id))
            {
                string prefix = person.GetType().Name.Substring(0, 1).ToUpper();
                person.Id = (GenerateNextPersonId(prefix));  
            }

            personList.Add(person);
        }
        public virtual void RemovePersonById(string id)
        {
            T personToRemove = personList.FirstOrDefault(person => person.Id == id);
            if (personToRemove != null)
            {
                personList.Remove(personToRemove);
            }
        }
        public virtual void UpdatePersonById(string id, T personInput)
        {
            T personToUpdate = personList.FirstOrDefault(person => person.Id == id);
            foreach (var person in personList)
            {
                if (person.Id == id)
                {
                    personToUpdate = personInput;
                    break;
                }

            }
        }
        public virtual void DisplayAllPersons()
        {
            foreach (var person in personList)
            {
                Console.WriteLine(person.ToString());
            }
        }
        public virtual void DisplayPersonDetails(string id)
        {
            T personToDisplay = null;

            foreach (var person in personList)
            {
                if (person.Id == id)
                {
                    personToDisplay = person;
                    break;
                }
            }
            if (personToDisplay != null)
            {
                Console.WriteLine(personToDisplay.ToString());
            }
        }
        public virtual T GetPersonById(string id)
        {
            return personList.FirstOrDefault(person => person.Id== id);
        }
        public virtual string GetIdByUsername(string username)
        {
            var staff = PersonList.Find(s => s.Username == username);
            return staff?.Id;
        }
        public virtual T GetPersonByUsernameAndPassword(string username, string password)
        {
            return PersonList.Find(s => s.Username == username && s.Password == password);
        }
    }
}
