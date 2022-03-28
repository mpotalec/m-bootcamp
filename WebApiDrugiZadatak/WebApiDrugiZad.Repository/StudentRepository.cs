using System.Collections.Generic;
using WebApiDrugiZadatak.Model;
using System.Data.SqlClient;
using System.Net;
using WebApiDrugiZadatak.Model;

namespace WebApiDrugiZad.Repository
{
    public class StudentRepository
    {
        static string connectionString = @"Data Source=DESKTOP-4UDNLBQ\SQLEXPRESS;Initial Catalog = SQLPersonStudent;Integrated Security = True";
        SqlConnection connection = new SqlConnection(connectionString);
        public List<Student> ShowAllStudents()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Student;", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                List<Student> studentList = new List<Student>();
                while (reader.Read())
                {

                    Student student = new Student();
                    student.PlaceOfResidence = reader.GetString(0);
                    student.SubjectOfStudent = reader.GetString(1);
                    student.Id = reader.GetInt32(2);

                    studentList.Add(student);

                }

                connection.Close();
                return studentList;

            }  else
            {
                return null;
            }
        }


        public Student InsertStudent(Student student)
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = new SqlCommand($"INSERT INTO Student VALUES ('{student.PlaceOfResidence}','{student.SubjectOfStudent}',{student.Id});", connection);
            adapter.InsertCommand.ExecuteNonQuery();
            connection.Close();
            return student;
        }


        public Student UpdateStudentById(int id, string subjectOfStudent)
        {
            SqlCommand commandRead = new SqlCommand($"SELECT * FROM Student WHERE Id={id};", connection);
            connection.Open();
            SqlDataReader reader = commandRead.ExecuteReader();
            if (reader.HasRows)
            {
                Student newStudent = new Student();
                while (reader.Read())
                {
                    newStudent.PlaceOfResidence = reader.GetString(0);
                    newStudent.SubjectOfStudent = subjectOfStudent;
                    newStudent.Id = reader.GetInt32(2);
                }
                reader.Close();
                SqlCommand commandAdapt = new SqlCommand($"UPDATE Student SET subjectOfStudent ='{subjectOfStudent}' WHERE Id={id}", connection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.UpdateCommand = commandAdapt;
                adapter.UpdateCommand.ExecuteNonQuery();
                connection.Close();
                return newStudent;
            }
            else
            {
                return null;
            }
        }


        public Student DeleteById(int id)
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM Student WHERE Id={id};", connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                Student newStudent = new Student();
                while (reader.Read())
                {
                    newStudent.PlaceOfResidence = reader.GetString(0);
                    newStudent.SubjectOfStudent = reader.GetString(1);
                    newStudent.Id = reader.GetInt32(2);
                }
                reader.Close();
                SqlCommand commandAdapter = new SqlCommand($"DELETE FROM Student WHERE Id={id};", connection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.DeleteCommand = commandAdapter;
                adapter.DeleteCommand.ExecuteNonQuery();
                connection.Close();
                return newStudent;
            }
            else { return null; }

        }
    }
}
