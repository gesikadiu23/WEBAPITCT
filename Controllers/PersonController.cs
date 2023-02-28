using FirstWebProj.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public static List<Person> persons = new List<Person>();

        [HttpPost("ShtoPerson")]
        public void AddPersons(Person person)
        {
            persons.Add(person);
        }

        [HttpGet("MerrPersonat")]
        public List<Person> GetPersons()
        {
            return persons;
        }


        [HttpGet("MerrPersonMeId")]
        public Person GetPersonById(int id)
        {
            return persons.Where(a => a.Id == id).FirstOrDefault();
        }


        [HttpGet("MerrPersonMeEmer")]

        public Person GetPersonByName(string name)
        {
            return persons.Where(a => a.Name == name).FirstOrDefault(); 
        }

        [HttpGet("MerrEmrinEPersonitMeId")]
        public string GetNameById(int id)
        {
            return persons.Where(a => a.Id == id).FirstOrDefault().Name;
        }

        [HttpDelete("FshiPerson")]
        public void DeletePerson(int id)
        {
            Person p = persons.FirstOrDefault(a => a.Id == id);

            persons.Remove(p);
        }
        

    }
}
