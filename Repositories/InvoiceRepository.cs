using InvoiceApp.EFCore.Data;
using InvoiceApp.EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoiceApi.Repositories
{

    // Repository class responsible for all database operations related to invoices.
    // Acts as a bridge between DbContext and the controller.

    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly InvoiceDbContext _context;


        // Injects the database context into the repository.
        public InvoiceRepository(InvoiceDbContext context)
        {
            _context = context;
        }


        // Retrieves all invoices with their items.
        public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
        {
            return await _context.Invoices
                .Include(i => i.Items) // Include related invoice items
                .ToListAsync();
        }


        // Retrieves a single invoice by its ID.
        public async Task<Invoice?> GetInvoiceByIdAsync(int id)
        {
            return await _context.Invoices
                .Include(i => i.Items)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        // Adds a new invoice to the database.
        public async Task<Invoice> CreateInvoiceAsync(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return invoice; // Returns the invoice with its new ID
        }


        // Updates an existing invoice.  
        public async Task UpdateInvoiceAsync(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync();
        }


        // Deletes an invoice by ID.
        public async Task DeleteInvoiceAsync(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                await _context.SaveChangesAsync();
            }
        }
    }
}
