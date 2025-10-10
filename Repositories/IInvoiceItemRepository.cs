using InvoiceApp.EFCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoiceApi.Repositories
{
    // Interface defining all operations for the InvoiceItemRepository.
    // Ensures the repository provides standard CRUD methods for invoice items.

    public interface IInvoiceItemRepository
    {
        // Retrieves all invoice items
        Task<IEnumerable<InvoiceItem>> GetAllItemsAsync();

        // Retrieves a single invoice item by ID
        Task<InvoiceItem?> GetItemByIdAsync(int id);

        // Creates a new invoice item and returns it
        Task<InvoiceItem> CreateItemAsync(InvoiceItem item);

        // Updates an existing invoice item
        Task UpdateItemAsync(InvoiceItem item);

        // Deletes an invoice item by ID
        Task DeleteItemAsync(int id);
    }
}
