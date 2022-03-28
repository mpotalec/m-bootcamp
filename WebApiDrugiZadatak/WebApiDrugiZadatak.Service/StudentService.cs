using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDrugiZadatak.Model;
using WebApiDrugiZad.Repository;

namespace WebApiDrugiZadatak.Service
{
    public class StudentService
    {
        public List<Student> ShowAllStudents()
        {
            StudentRepository studentRepository = new StudentRepository();
            return studentRepository.ShowAllStudents();
        }

        public Student InsertStudent(Student student)
        {
            StudentRepository studentRepository = new StudentRepository();
            return studentRepository.InsertStudent(student);
        }

        public Student UpdateStudentById(int id, string studentName)
        {
            StudentRepository studentRepository=new StudentRepository();
            return studentRepository.UpdateStudentById(id,studentName);
        }

        public Student DeleteById(int id)
        {
            StudentRepository studentRepository = new StudentRepository();
            return studentRepository.DeleteById(id);
        }
    }
}
