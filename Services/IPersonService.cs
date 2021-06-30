using System.Collections.Generic;
using API2.Models;

namespace API2.Services {
    public interface IPersonService
    {
        Person GetOne(int id);
        List<Person> GetAll();
        List<Person> Filter(string firstName, string lastName, string gender, string birthPlace);
        void Create(Person model);
        void Edit(int id, Person model);
        void Delete(int id);
    }
}