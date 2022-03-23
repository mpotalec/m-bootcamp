using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDrugiZadatak.Models;

namespace WebApiDrugiZadatak.Controllers
{
    public class PersonController : ApiController
    {
        List<Person> personList = new List<Person>()
        {
            new Person(){ FirstName = "Matko", LastName = "Potalec", Id = 1},
            new Person(){ FirstName = "Magdalena", LastName = "Cavic", Id = 2},
            new Person(){ FirstName = "Ciri", LastName = "Luna", Id = 3}
        };

        [HttpGet]
        public HttpResponseMessage Gets() //call all persons
        {
            if(personList.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, personList);
        }

        
        public HttpResponseMessage Get(int id)  //find person by id
        {
            var idPerson = personList.Find(x => x.Id == id);
            if (idPerson == null)
            {
                Request.CreateResponse(HttpStatusCode.BadRequest, "0 found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, idPerson);
        }

        [HttpPost]
        public void CreateNewStudent(Person idPerson)
        {
            if(idPerson == null) { return; }
            if(personList.Count==0)
            {
                idPerson.Id = 1;
            } else { idPerson.Id = personList.Last().Id + 1; }
            personList.Add(idPerson);
        }
        // DELETE api/person/delete/1
        [HttpDelete]
        [Route("api/person/delete/{id}")]
        public HttpResponseMessage DeletePersonById(int id)
        {
            var delPerson = personList.Find(x => x.Id == id);

            if (delPerson == null)
            { Request.CreateResponse(HttpStatusCode.BadRequest, $"Person {id} not found"); }

            personList.Remove(delPerson);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}



