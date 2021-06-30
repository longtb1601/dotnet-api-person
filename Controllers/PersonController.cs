using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API2.Models;
using API2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost("/person")]
        public ActionResult<bool> Create(Person person)
        {
            try {

                _personService.Create(person);

                return Ok($"Create new person successfully!");

            } catch (Exception e) {

                return NotFound($"Error: {e.Message}");

            }
        }

        [HttpGet("/people")]
        public List<Person> GetAll() 
        {
            return _personService.GetAll();
        }

        [HttpGet("/person/{id}")]
        public ActionResult<Person> GetOne(int id) 
        {
            return _personService.GetOne(id);
        }

        [HttpPut("/person/{id}")]
        public IActionResult Edit(int id, Person person)
        {
            try 
            {
                _personService.Edit(id, person);

                return Ok($"Edit person {person.FirstName} {person.LastName} successfully!");
            } 
            catch (Exception e)
            {
                return NotFound($"Error: {e.Message}");
            }
        }

        [HttpDelete("/person/{id}")]
        public IActionResult Delete(int id)
        {
            try {

                var person = _personService.GetOne(id);

                _personService.Delete(id);

                return Ok($"Delete person {person.FirstName} {person.LastName} successfully!");

            } catch (Exception e) {

                return NotFound($"Error: {e.Message}");

            }
        }

        [HttpGet("/people/{firstName}/{lastName}/{gender}/{birthPlace}")]
        public List<Person> Filter(string firstName, string lastName, string gender, string birthPlace)
        {
            return _personService.Filter(firstName, lastName, gender, birthPlace);
        }

    }

}