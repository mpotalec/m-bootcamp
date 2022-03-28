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
using Student = WebApiDrugiZadatak.Model.Student;

namespace WebApiDrugiZadatak.Controllers
{
    public class StudentController : ApiController
    {

        [HttpGet]
        [Route("api/ShowAllStudents")]
        public HttpResponseMessage ShowAllStudents()
        {
            StudentService service = new StudentService();
            List<Student> studentList = new List<Student>();

            studentList = service.ShowAllStudents();

            if (studentList != null)
            {
                //List<StudentModel> studentsMapped = new List<StudentModel>();
                //foreach (StudentModel student in studentList)
                //{
                //    StudentRest studentRest = new StudentRest();
                //    studentRest.SubjectOfStudent = student.SubjectOfStudent;
                //    studentRest.Id = student.Id;

                //    studentsMapped.Add(studentRest);
                //}
                return Request.CreateResponse(HttpStatusCode.OK, studentList);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Not found");
            }
        }




        [HttpPost]
        [Route("api/InsertStudent")]
        public HttpResponseMessage InsertStudent(Model.Student student)
        {
            StudentService service = new StudentService();
            Student newStudent = new Student();

            newStudent = service.InsertStudent(student);

            StudentRest studentRest = new StudentRest();
            studentRest.SubjectOfStudent = newStudent.SubjectOfStudent;
            studentRest.Id = newStudent.Id;

            return Request.CreateResponse(HttpStatusCode.OK, studentRest);
        }


        [HttpPut]
        [Route("api/UpdateStudent")]
        public HttpResponseMessage UpdateStudentById(int id, string studentName)
        {
            StudentService service = new StudentService();
            Student newStudent = new Student();
            newStudent = service.UpdateStudentById(id, studentName);
            if(newStudent != null)
            {
                StudentRest studentMapped = new StudentRest();
                studentMapped.SubjectOfStudent = newStudent.SubjectOfStudent;
                studentMapped.Id = newStudent.Id;

                return Request.CreateResponse(HttpStatusCode.OK, studentMapped);
            }   else
            {
                return Request.CreateResponse(HttpStatusCode.OK, $"Not found");
            }
        }


        [HttpDelete]
        [Route("api/Delete")]
        public HttpResponseMessage DeleteById(int id)
        {
            StudentService service = new StudentService();
            Model.Student newStudent = new Model.Student();
            newStudent = service.DeleteById(id);
            if(newStudent != null )
            {
                StudentRest studentMapped = new StudentRest();
                studentMapped.SubjectOfStudent = newStudent.SubjectOfStudent;
                studentMapped.Id = newStudent.Id;

                return Request.CreateResponse(HttpStatusCode.OK, studentMapped);
            }   else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Not foud");
            }
        }
    }
}

public class StudentRest
{
    public string SubjectOfStudent { get; set; } = "";
    public int Id { get; set; } = 0;
}





