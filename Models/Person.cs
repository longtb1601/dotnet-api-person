using System;

namespace API2.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth {get; set; }
        public string Gender { get; set; }
        public string BirthPlace { get; set; }
    }
}