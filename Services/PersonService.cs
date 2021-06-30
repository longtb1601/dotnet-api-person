using System;
using System.Collections.Generic;
using System.Linq;
using API2.Models;

namespace API2.Services
{
    public class PersonService : IPersonService
    {
        private PersonContext _personContext;
        public PersonService(PersonContext personContext)
        {
            _personContext = personContext;
        }

        public List<Person> GetAll()
        {
            return _personContext.People.ToList();
        }

        public Person GetOne(int id)
        {
            var person = _personContext.People.Find(id);

            return person;
        }

        public void Create(Person person)
        {
            _personContext.Add<Person>(person);

            _personContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var person = _personContext.People.Find(id);

            _personContext.Remove(person);

            _personContext.SaveChanges();
        }

        public void Edit(int id, Person person)
        {
            var personEdit = _personContext.People.Find(id);

            personEdit = person;

            _personContext.SaveChanges();
        }

        public List<Person> Filter(string firstName, string lastName, string gender, string birthPlace)
        {
            return _personContext.People.Where(p => (!string.IsNullOrEmpty(firstName) && p.FirstName.Equals(firstName, StringComparison.CurrentCultureIgnoreCase)) ||
                                                    (!string.IsNullOrEmpty(lastName) && p.LastName.Equals(lastName, StringComparison.CurrentCulture)) ||
                                                    (!string.IsNullOrEmpty(birthPlace) && p.BirthPlace.Equals(birthPlace, StringComparison.CurrentCulture)) ||
                                                    (!string.IsNullOrEmpty(gender) && p.Gender.Equals(gender, StringComparison.CurrentCulture))).ToList();
        }
    }
}