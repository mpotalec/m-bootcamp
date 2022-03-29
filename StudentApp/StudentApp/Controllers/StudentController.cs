using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentApp.Model;
using StudentApp.Service;
using Student = StudentApp.Model.Student;
using System.Threading.Tasks;

namespace StudentApp.Controllers
{
    public class StudentController : ApiController
    {

        [HttpGet]
        [Route("api/ShowAllStudents")]
        public async Task<HttpResponseMessage> ShowAllStudentsAsync()
        {
            StudentService service = new StudentService();
            List<Student> studentList = new List<Student>();

            studentList = await service.ShowAllStudentsAsync();

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
        public async Task<HttpResponseMessage> InsertStudentAsync(Model.Student student)
        {
            StudentService service = new StudentService();
            Student newStudent = new Student();

            newStudent = await service.InsertStudentAsync(student);

            StudentRest studentRest = new StudentRest();
            studentRest.SubjectOfStudent = newStudent.SubjectOfStudent;
            studentRest.Id = newStudent.Id;

            return Request.CreateResponse(HttpStatusCode.OK, studentRest);
        }


        [HttpPut]
        [Route("api/UpdateStudent")]
        public async Task<HttpResponseMessage> UpdateStudentByIdAsync(int id, string studentName)
        {
            StudentService service = new StudentService();
            Student newStudent = new Student();
            newStudent = await service.UpdateStudentByIdAsync(id, studentName);
            if (newStudent != null)
            {
                StudentRest studentMapped = new StudentRest();
                studentMapped.SubjectOfStudent = newStudent.SubjectOfStudent;
                studentMapped.Id = newStudent.Id;

                return Request.CreateResponse(HttpStatusCode.OK, studentMapped);
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
            StudentService service = new StudentService();
            Model.Student newStudent = new Model.Student();
            newStudent = await service.DeleteByIdAsync(id);
            if (newStudent != null)
            {
                StudentRest studentMapped = new StudentRest();
                studentMapped.SubjectOfStudent = newStudent.SubjectOfStudent;
                studentMapped.Id = newStudent.Id;

                return Request.CreateResponse(HttpStatusCode.OK, studentMapped);
            }
            else
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
