using System.Collections.Generic;
using StudentApp.Model;
using System.Data.SqlClient;
using System.Net;
using StudentApp.Model;
using System.Threading.Tasks;
using StudentApp.Repository.Common;

namespace StudentApp.Repository
{
    public class StudentRepository
    {
        static string connectionString = @"Data Source=DESKTOP-4UDNLBQ\SQLEXPRESS;Initial Catalog = SQLPersonStudent;Integrated Security = True";
        SqlConnection connection = new SqlConnection(connectionString);
        public async Task<List<Student>> ShowAllStudentsAsync()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Student;", connection);
            await connection.OpenAsync();
            SqlDataReader reader =await command.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                List<Student> studentList = new List<Student>();
                while (await reader.ReadAsync())
                {

                    Student student = new Student();
                    student.PlaceOfResidence = reader.GetString(0);
                    student.SubjectOfStudent = reader.GetString(1);
                    student.Id = reader.GetInt32(2);

                    studentList.Add(student);

                }

                connection.Close();
                return studentList;

            }
            else
            {
                return null;
            }
        }


        public async Task<Student> InsertStudentAsync(Student student)
        {
            await connection.OpenAsync();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = new SqlCommand($"INSERT INTO Student VALUES ('{student.PlaceOfResidence}','{student.SubjectOfStudent}',{student.Id});", connection);
            await adapter.InsertCommand.ExecuteNonQueryAsync();
            connection.Close();
            return student;
        }


        public async Task<Student> UpdateStudentByIdAsync(int id, string PlaceOfResidence)
        {
            SqlCommand commandReader = new SqlCommand($"SELECT * FROM Student WHERE Id={id};", connection);
            await connection.OpenAsync();

            SqlDataReader reader = await commandReader.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                Student newStudent = new Student();
                while (await reader.ReadAsync())
                {
                    Student student = new Student();
                    student.PlaceOfResidence = PlaceOfResidence;
                    student.SubjectOfStudent = reader.GetString(1);
                    student.Id = reader.GetInt32(2);
                }
                reader.Close();
                SqlCommand commandAdapter = new SqlCommand($"UPDATE Student SET PlaceOfResidence='{PlaceOfResidence}' WHERE Id={id};", connection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.UpdateCommand = commandAdapter;
                await adapter.UpdateCommand.ExecuteNonQueryAsync();
                connection.Close();
                return newStudent;
            }
            else
            {
                return null;
            }
        }


        public async Task<Student> DeleteByIdAsync(int id)
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM Student WHERE Id={id};", connection);
            await connection.OpenAsync();

            SqlDataReader reader =await command.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                Student newStudent = new Student();
                while (await reader.ReadAsync())
                {
                    newStudent.PlaceOfResidence = reader.GetString(0);
                    newStudent.SubjectOfStudent = reader.GetString(1);
                    newStudent.Id = reader.GetInt32(2);
                }
                reader.Close();
                SqlCommand commandAdapter = new SqlCommand($"DELETE FROM Student WHERE Id={id};", connection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.DeleteCommand = commandAdapter;
                await adapter.DeleteCommand.ExecuteNonQueryAsync();
                connection.Close();
                return newStudent;
            }
            else { return null; }

        }
    }
}
