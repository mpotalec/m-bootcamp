using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentApp.Repository;
using StudentApp.Model;
using StudentApp.Service.Common;

namespace StudentApp.Service
{
    public class PersonService 
    {
        public async  Task<List<Person>> ShowAllPeopleAsync()
        {
            PersonRepository personRepository = new PersonRepository();
            return await personRepository.ShowAllPeopleAsync();
        }

        public async Task<Person> InsertPersonAsync(Person person)
        {
            PersonRepository personRepository = new PersonRepository();
            return await personRepository.InsertPersonAsync(person);
        }

        public async Task<Person> UpdatePersonByIdAsync(int id, string personName)
        {
            PersonRepository personRepository = new PersonRepository();
            return await personRepository.UpdatePersonByIdAsync(id, personName);
        }

        public async Task<Person> DeletePersonAsync(int id)
        {
            PersonRepository personRepository = new PersonRepository();
            return await personRepository.DeletePersonAsync(id);
        }
    }
}


