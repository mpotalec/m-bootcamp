using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDrugiZadatak.Models;
using WebApiDrugiZadatak.Model;
using WebApiDrugiZadatak.Service;
using Person = WebApiDrugiZadatak.Model.Person;




namespace WebApiDrugiZadatak.Controllers
{
    public class PersonController : ApiController
    {

        [HttpGet]
        [Route("api/ShowAllPeople")]
        public HttpResponseMessage ShowAllPeople()
        {
            PersonService service = new PersonService();
            List<Person> personList = new List<Person>();

            personList = service.ShowAllPeople();

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
        public HttpResponseMessage InsertPerson(Person person)
        {
            PersonService service = new PersonService();
            Person newPerson = new Person();

            newPerson = service.InsertPerson(person);

            PersonRest personRest = new PersonRest();
            personRest.FirstName = newPerson.FirstName;
            personRest.Id = newPerson.Id;

            return Request.CreateResponse(HttpStatusCode.OK, personRest);
        }


        [HttpPut]
        [Route("api/UpdatePerson")]
        public HttpResponseMessage UpdatePersonById(int id, string personName)
        {
            PersonService service = new PersonService();
            Person newPerson = new Person();
            newPerson = service.UpdatePersonById(id, personName);
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
        public HttpResponseMessage DeleteById(int id)
        {
            PersonService service = new PersonService();
            Model.Person newPerson = new Model.Person();
            newPerson = service.DeletePerson(id);
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




