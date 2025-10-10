using InvoiceApp.EFCore.Data;
using InvoiceApp.EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoiceApi.Repositories
{
    // Repository class responsible for all database operations related to invoice items.
    // Acts as a bridge between DbContext and the controller.
    public class InvoiceItemRepository : IInvoiceItemRepository
    {
        private readonly InvoiceDbContext _context;

        // Injects the database context into the repository.
        public InvoiceItemRepository(InvoiceDbContext context)
        {
            _context = context;
        }

        // Retrieves all invoice items from the database.
        public async Task<IEnumerable<InvoiceItem>> GetAllItemsAsync()
        {
            return await _context.InvoiceItems.ToListAsync();
        }

        // Retrieves a single invoice item by its ID.
        public async Task<InvoiceItem?> GetItemByIdAsync(int id)
        {
            return await _context.InvoiceItems.FirstOrDefaultAsync(i => i.Id == id);
        }

        // Adds a new invoice item to the database.
        public async Task<InvoiceItem> CreateItemAsync(InvoiceItem item)
        {
            _context.InvoiceItems.Add(item);
            await _context.SaveChangesAsync();
            return item; // Returns the item with its new ID
        }

        // Updates an existing invoice item.
        public async Task UpdateItemAsync(InvoiceItem item)
        {
            _context.InvoiceItems.Update(item);
            await _context.SaveChangesAsync();
        }

        // Deletes an invoice item by ID.
        public async Task DeleteItemAsync(int id)
        {
            var item = await _context.InvoiceItems.FindAsync(id);
            if (item != null)
            {
                _context.InvoiceItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
