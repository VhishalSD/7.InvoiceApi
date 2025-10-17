using InvoiceApp.EFCore.Data;
using InvoiceApp.EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceApi.Repositories
{
    /// <summary>
    /// Handles all database operations related to invoices.
    /// </summary>
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly InvoiceDbContext _context;

        /// <summary>
        /// Initializes a new instance of InvoiceRepository.
        /// </summary>
        public InvoiceRepository(InvoiceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "Database context cannot be null.");
        }

        /// <summary>
        /// Retrieves all invoices from the database.
        /// </summary>
        public IEnumerable<Invoice> GetAll()
        {
            return _context.Invoices
                .Include(i => i.Items)
                .ToList();
        }

        /// <summary>
        /// Retrieves a specific invoice by ID.
        /// </summary>
        public Invoice GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid ID. Must be greater than zero.");
            }

            var invoice = _context.Invoices
                .Include(i => i.Items)
                .FirstOrDefault(i => i.Id == id);

            if (invoice == null)
            {
                throw new InvalidOperationException($"Invoice with ID {id} not found.");
            }

            return invoice;
        }

        /// <summary>
        /// Adds a new invoice to the database.
        /// </summary>
        public string Add(Invoice invoice)
        {
            if (invoice == null)
            {
                return "Error: Invoice cannot be null.";
            }

            _context.Invoices.Add(invoice);
            _context.SaveChanges();
            return $"Invoice for customer '{invoice.CustomerName}' has been added successfully.";
        }

        /// <summary>
        /// Updates an existing invoice.
        /// </summary>
        public string Update(Invoice invoice)
        {
            if (invoice == null)
            {
                return "Error: Invoice cannot be null.";
            }

            var existingInvoice = _context.Invoices
                .Include(i => i.Items)
                .FirstOrDefault(i => i.Id == invoice.Id);

            if (existingInvoice == null)
            {
                return $"Error: Invoice with ID {invoice.Id} not found.";
            }

            existingInvoice.CustomerName = invoice.CustomerName;
            existingInvoice.CustomerEmail = invoice.CustomerEmail;
            existingInvoice.Description = invoice.Description;
            existingInvoice.InvoiceDate = invoice.InvoiceDate;
            existingInvoice.Items = invoice.Items;

            _context.SaveChanges();
            return $"Invoice for customer '{invoice.CustomerName}' has been updated successfully.";
        }

        /// <summary>
        /// Deletes an invoice by ID.
        /// </summary>
        public string Delete(int id)
        {
            if (id <= 0)
            {
                return "Error: Invalid ID.";
            }

            var invoice = _context.Invoices.Find(id);
            if (invoice == null)
            {
                return $"Error: Invoice with ID {id} not found.";
            }

            _context.Invoices.Remove(invoice);
            _context.SaveChanges();
            return $"Invoice with ID {id} has been deleted successfully.";
        }
    }
}
