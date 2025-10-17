
using InvoiceApp.EFCore.Models;
using System.Collections.Generic;

namespace InvoiceApi.Repositories
{
    /// <summary>
    /// Defines all operations that can be performed on invoices.
    /// </summary>
    public interface IInvoiceRepository
    {
        /// <summary>
        /// Retrieves all invoices.
        /// </summary>
        IEnumerable<Invoice> GetAll();

        /// <summary>
        /// Retrieves a specific invoice by ID.
        /// </summary>
        Invoice GetById(int id);

        /// <summary>
        /// Adds a new invoice.
        /// </summary>
        string Add(Invoice invoice);

        /// <summary>
        /// Updates an existing invoice.
        /// </summary>
        string Update(Invoice invoice);

        /// <summary>
        /// Deletes an invoice by ID.
        /// </summary>
        string Delete(int id);
    }
}
