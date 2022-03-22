using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDrugiZadatak.Models;

namespace WebApiDrugiZadatak.Controllers
{
    public class ProfessorController : ApiController
    {
        List<Professor> professorList = new List<Professor>()
        {
            new Professor(){ FirstName = "Ivan", Subject = "Biology", Id = 1},
            new Professor(){ FirstName = "Marko", Subject = "Math", Id = 2},
            new Professor(){ FirstName = "Ante", Subject = "Physical Ed.", Id = 3},

        };

        [HttpGet]
        public HttpResponseMessage Gets() //call all professors
        {
            if (professorList.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, professorList);
        }


        public HttpResponseMessage Get(int id)  //find professor by id
        {
            var idProfessor = professorList.Find(x => x.Id == id);
            if (idProfessor == null)
            {
                Request.CreateResponse(HttpStatusCode.BadRequest, "0 found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, idProfessor);
        }

        [HttpPost]
        public void CreateNewStudent(Professor idProfessor)
        {
            if (idProfessor == null) { return; }
            if (professorList.Count == 0)
            {
                idProfessor.Id = 1;
            }
            else { idProfessor.Id = professorList.Last().Id + 1; }
            professorList.Add(idProfessor);
        }


        // DELETE api/professor/delete/1
        [HttpDelete]
        [Route("api/professor/delete/{id}")]
        public HttpResponseMessage DeleteProfessorById(int id)
        {
            var delProfessor = professorList.Find(x => x.Id == id);

            if (delProfessor == null)
            { Request.CreateResponse(HttpStatusCode.BadRequest, $"Professor {id} not found"); }

            professorList.Remove(delProfessor);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
