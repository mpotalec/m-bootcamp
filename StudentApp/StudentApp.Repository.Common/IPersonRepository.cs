using StudentApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Repository.Common
{
    public interface IPersonRepository
    {
        Task<List<Person>> ShowAllPeopleAsync();
        Task<Person> InsertPersonsAsync(Person person);
        Task UpdatePersonByIdAsync(int id, string personName);
        Task DeleteByIdAsync(int id);
    }
}
