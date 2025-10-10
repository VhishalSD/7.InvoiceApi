using InvoiceApp.EFCore.Data;
using InvoiceApp.EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoiceApi.Repositories
{
    // Repository class responsible for all database operations related to people.
    // Acts as a bridge between DbContext and the controller.
    public class PersonRepository : IPersonRepository
    {
        private readonly InvoiceDbContext _context;

        // Injects the database context into the repository.
        public PersonRepository(InvoiceDbContext context)
        {
            _context = context;
        }

        // Retrieves all people from the database.
        public async Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            return await _context.People
                .ToListAsync();
        }

        // Retrieves a single person by their ID.
        public async Task<Person?> GetPersonByIdAsync(int id)
        {
            return await _context.People
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // Adds a new person to the database.
        public async Task<Person> CreatePersonAsync(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
            return person; // Returns the person with its new ID
        }

        // Updates an existing person.
        public async Task UpdatePersonAsync(Person person)
        {
            _context.People.Update(person);
            await _context.SaveChangesAsync();
        }

        // Deletes a person by ID.
        public async Task DeletePersonAsync(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person != null)
            {
                _context.People.Remove(person);
                await _context.SaveChangesAsync();
            }
        }
    }
}
