using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDrugiZad.Repository;
using WebApiDrugiZadatak.Model;

namespace WebApiDrugiZadatak.Service
{
    public class PersonService
    {
        public List<Person> ShowAllPeople()
        {
            PersonRepository personRepository = new PersonRepository();
            return personRepository.ShowAllPeople();
        }

        public Person InsertPerson(Person person)
        {
            PersonRepository personRepository = new PersonRepository();
            return personRepository.InsertPerson(person);
        }

        public Person UpdatePersonById(int id, string personName)
        {
            PersonRepository personRepository = new PersonRepository();
            return personRepository.UpdatePersonById(id, personName);
        }

        public Person DeletePerson(int id)
        {
            PersonRepository personRepository = new PersonRepository();
            return personRepository.DeletePerson(id);
        }
    }
}
