using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using WebApiDrugiZadatak.Model;
using System.Collections.Generic;
using WebApiDrugiZadatak.Model;
using System.Data.SqlClient;
using System.Net;
using WebApiDrugiZadatak.Model;


namespace WebApiDrugiZad.Repository
{
    public class PersonRepository
    {
        static string connectionString = @"Data Source=DESKTOP-4UDNLBQ\SQLEXPRESS;Initial Catalog = SQLPersonStudent;Integrated Security = True";
        SqlConnection connection = new SqlConnection(connectionString);

        public List<Person> ShowAllPeople()
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM Person;", connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                List<Person> personList = new List<Person>();
                while (reader.Read())
                {
                    Person person = new Person();
                    person.FirstName = reader.GetString(0);
                    person.LastName = reader.GetString(1);
                    person.Id = reader.GetInt32(2);

                    personList.Add(person);
                }
                connection.Close();
                return personList;
            }  else 
            { 
                return null;
            }
        }

        public Person InsertPerson(Person person)
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = new SqlCommand($"INSERT INTO Person VALUES ('{person.FirstName}','{person.LastName}',{person.Id});", connection);
            adapter.InsertCommand.ExecuteNonQuery();
            connection.Close();
            return person;

        }


        public Person UpdatePersonById(int id, string FirstName)
        {
            SqlCommand commandReader = new SqlCommand($"SELECT * FROM Person WHERE Id={id};", connection);
            connection.Open();

            SqlDataReader reader = commandReader.ExecuteReader();
            if (reader.HasRows)
            {
                Person newPerson = new Person();
                while (reader.Read())
                {
                    Person person = new Person();
                    person.FirstName = FirstName;
                    person.LastName = reader.GetString(1);
                    person.Id = reader.GetInt32(2);
                }
                reader.Close();
                SqlCommand commandAdapter = new SqlCommand($"UPDATE Person SET FirstName='{FirstName}' WHERE Id={id};", connection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.UpdateCommand = commandAdapter;
                adapter.UpdateCommand.ExecuteNonQuery();
                connection.Close ();
                return newPerson;
            }
            else
            {
                return null;
            }
        }



        public Person DeletePerson(int id)
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM Person WHERE Id={id};", connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                Person newPerson = new Person();
                while (reader.Read())
                {
                    newPerson.FirstName = reader.GetString(0);
                    newPerson.LastName = reader.GetString(1);
                    newPerson.Id = reader.GetInt32(2);
                }
                reader.Close();
                SqlCommand commandAdapter = new SqlCommand($"DELETE FROM Person WHERE Id={id};", connection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.DeleteCommand = commandAdapter;
                adapter.DeleteCommand.ExecuteNonQuery();
                connection.Close();
                return newPerson;
            }   else { return null; }
        }
    }
}
