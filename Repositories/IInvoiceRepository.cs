using InvoiceApp.EFCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoiceApi.Repositories
{
    // Interface defining all operations for the InvoiceRepository.
    // Ensures the repository provides standard CRUD methods.

    public interface IInvoiceRepository
    {
        // Retrieves all invoices with their items
        Task<IEnumerable<Invoice>> GetAllInvoicesAsync();

        // Retrieves a single invoice by its ID
        Task<Invoice?> GetInvoiceByIdAsync(int id);

        // Creates a new invoice and returns it (including generated ID)
        Task<Invoice> CreateInvoiceAsync(Invoice invoice);

        // Updates an existing invoice
        Task UpdateInvoiceAsync(Invoice invoice);

        // Deletes an invoice by its ID
        Task DeleteInvoiceAsync(int id);
    }
}
