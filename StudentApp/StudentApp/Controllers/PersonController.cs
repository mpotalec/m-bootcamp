using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentApp.Model;
using StudentApp.Service;
using Person = StudentApp.Model.Person;
using System.Threading.Tasks;

namespace StudentApp.Controllers
{
    public class PersonController : ApiController
    {

        [HttpGet]
        [Route("api/ShowAllPeople")]
        public async Task<HttpResponseMessage> ShowAllPeopleAsync()
        {
            PersonService service = new PersonService();
            List<Person> personList = new List<Person>();

            personList = await service.ShowAllPeopleAsync();

            if (personList != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, personList);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Not found");
            }
        }




        [HttpPost]
        [Route("api/InsertPerson")]
        public async Task<HttpResponseMessage> InsertPersonAsync(Person person)
        {
            PersonService service = new PersonService();
            Person newPerson = new Person();

            newPerson = await service.InsertPersonAsync(person);

            PersonRest personRest = new PersonRest();
            personRest.FirstName = newPerson.FirstName;
            personRest.Id = newPerson.Id;

            return Request.CreateResponse(HttpStatusCode.OK, personRest);
        }


        [HttpPut]
        [Route("api/UpdatePerson")]
        public async Task<HttpResponseMessage> UpdatePersonByIdAsync(int id, string personName)
        {
            PersonService service = new PersonService();
            Person newPerson = new Person();
            newPerson = await service.UpdatePersonByIdAsync(id, personName);
            if (newPerson != null)
            {
                PersonRest personMapped = new PersonRest();
                personMapped.FirstName = newPerson.FirstName;
                personMapped.Id = newPerson.Id;

                return Request.CreateResponse(HttpStatusCode.OK, personMapped);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, $"Not found");
            }
        }


        [HttpDelete]
        [Route("api/Delete")]
        public async Task<HttpResponseMessage> DeleteByIdAsync(int id)
        {
            PersonService service = new PersonService();
            Model.Person newPerson = new Model.Person();
            newPerson = await service.DeletePersonAsync(id);
            if (newPerson != null)
            {
                PersonRest personMapped = new PersonRest();
                personMapped.FirstName = newPerson.FirstName;
                personMapped.Id = newPerson.Id;

                return Request.CreateResponse(HttpStatusCode.OK, personMapped);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Not foud");
            }
        }
    }
}

public class PersonRest
{
    public string FirstName { get; set; } = "";
    public int Id { get; set; } = 0;
}




