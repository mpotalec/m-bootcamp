using StudentApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Service.Common
{
    public interface IStudentService
    {
        Task<List<Student>> ShowAllStudentsAsync();
        Task<Student> InsertStudentsAsync(Student student);
        Task UpdateStudentByIdAsync(int id, string PlaceOfResidence);
        Task DeleteByIdAsync(int id);
    }
}
