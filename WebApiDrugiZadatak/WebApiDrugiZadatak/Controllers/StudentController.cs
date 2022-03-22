using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDrugiZadatak.Models;

namespace WebApiDrugiZadatak.Controllers
{
    public class StudentController : ApiController
    {
        List<Student> studentList = new List<Student>()
        {
            new Student(){ FirstName = "Matko", LastName = "Potalec", Id = 1},
            new Student(){ FirstName = "Magdalena", LastName = "Cavic", Id = 2},
            new Student(){ FirstName = "Ciri", LastName = "Luna", Id = 3}
        };

        [HttpGet]
        public HttpResponseMessage Gets() //call all students
        {
            if(studentList.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, studentList);
        }

        
        public HttpResponseMessage Get(int id)  //find student by id
        {
            var idStudent = studentList.Find(x => x.Id == id);
            if (idStudent == null)
            {
                Request.CreateResponse(HttpStatusCode.BadRequest, "0 found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, idStudent);
        }

        [HttpPost]
        public void CreateNewStudent(Student idStudent)
        {
            if(idStudent == null) { return; }
            if(studentList.Count==0)
            {
                idStudent.Id = 1;
            } else { idStudent.Id = studentList.Last().Id + 1; }
            studentList.Add(idStudent);
        }
        // DELETE api/student/delete/1
        [HttpDelete]
        [Route("api/student/delete/{id}")]
        public HttpResponseMessage DeleteStudentById(int id)
        {
            var delStudent = studentList.Find(x => x.Id == id);

            if (delStudent == null)
            { Request.CreateResponse(HttpStatusCode.BadRequest, $"Student {id} not found"); }

            studentList.Remove(delStudent);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}



