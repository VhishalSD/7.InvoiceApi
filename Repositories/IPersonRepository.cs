using InvoiceApp.EFCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoiceApi.Repositories
{
    // Interface defining all operations for the PersonRepository.
    // Ensures the repository provides standard CRUD methods for people.

    public interface IPersonRepository
    {
        // Retrieves all people
        Task<IEnumerable<Person>> GetAllPeopleAsync();

        // Retrieves a single person by ID
        Task<Person?> GetPersonByIdAsync(int id);

        // Creates a new person and returns it
        Task<Person> CreatePersonAsync(Person person);

        // Updates an existing person
        Task UpdatePersonAsync(Person person);

        // Deletes a person by ID
        Task DeletePersonAsync(int id);
    }
}
