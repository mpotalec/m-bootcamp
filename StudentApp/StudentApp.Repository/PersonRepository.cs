using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using StudentApp.Model;
using System.Collections.Generic;
using StudentApp.Model;
using System.Data.SqlClient;
using System.Net;
using StudentApp.Model;
using StudentApp.Repository.Common;

namespace StudentApp.Repository
{
    public class PersonRepository
    {
        static string connectionString = @"Data Source=DESKTOP-4UDNLBQ\SQLEXPRESS;Initial Catalog = SQLPersonStudent;Integrated Security = True";
        SqlConnection connection = new SqlConnection(connectionString);

        public async Task<List<Person>> ShowAllPeopleAsync()
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM Person;", connection);
            await connection.OpenAsync();

            SqlDataReader reader = await command.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                List<Person> personList = new List<Person>();
                while (await reader.ReadAsync())
                {
                    Person person = new Person();
                    person.FirstName = reader.GetString(0);
                    person.LastName = reader.GetString(1);
                    person.Id = reader.GetInt32(2);

                    personList.Add(person);
                }
                connection.Close();
                return personList;
            }
            else
            {
                return null;
            }
        }

        public async Task<Person> InsertPersonAsync(Person person)
        {
            await connection.OpenAsync();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = new SqlCommand($"INSERT INTO Person VALUES ('{person.FirstName}','{person.LastName}',{person.Id});", connection);
            await adapter.InsertCommand.ExecuteNonQueryAsync();
            connection.Close();
            return person;

        }


        public async Task<Person> UpdatePersonByIdAsync(int id, string FirstName)
        {
            SqlCommand commandReader = new SqlCommand($"SELECT * FROM Person WHERE Id={id};", connection);
            await connection.OpenAsync();

            SqlDataReader reader = await commandReader.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                Person newPerson = new Person();
                while (await reader.ReadAsync())
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
                await adapter.UpdateCommand.ExecuteNonQueryAsync();
                connection.Close();
                return newPerson;
            }
            else
            {
                return null;
            }
        }



        public async Task<Person> DeletePersonAsync(int id)
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM Person WHERE Id={id};", connection);
            await connection.OpenAsync();

            SqlDataReader reader = await command.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                Person newPerson = new Person();
                while (await reader.ReadAsync())
                {
                    newPerson.FirstName = reader.GetString(0);
                    newPerson.LastName = reader.GetString(1);
                    newPerson.Id = reader.GetInt32(2);
                }
                reader.Close();
                SqlCommand commandAdapter = new SqlCommand($"DELETE FROM Person WHERE Id={id};", connection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.DeleteCommand = commandAdapter;
                await adapter.DeleteCommand.ExecuteNonQueryAsync();
                connection.Close();
                return newPerson;
            }
            else { return null; }
        }
    }
}


