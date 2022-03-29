using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentApp.Model;
using StudentApp.Repository;
using StudentApp.Service.Common;

namespace StudentApp.Service
{
    public class StudentService 
    {
        public async Task<List<Student>> ShowAllStudentsAsync()
        {
            StudentRepository studentRepository = new StudentRepository();
            return await studentRepository.ShowAllStudentsAsync();
        }

        public async Task<Student> InsertStudentAsync(Student student)
        {
            StudentRepository studentRepository = new StudentRepository();
            return await studentRepository.InsertStudentAsync(student);
        }

        public async Task<Student> UpdateStudentByIdAsync(int id, string studentName)
        {
            StudentRepository studentRepository = new StudentRepository();
            return await studentRepository.UpdateStudentByIdAsync(id, studentName);
        }

        public async Task<Student> DeleteByIdAsync(int id)
        {
            StudentRepository studentRepository = new StudentRepository();
            return await studentRepository.DeleteByIdAsync(id);
        }
    }
}
