
using InvoiceApi.Repositories;
using InvoiceApp.EFCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InvoiceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;

        /// <summary>
        /// Initializes the controller with the repository.
        /// </summary>
        public InvoicesController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        /// <summary>
        /// Retrieves all invoices.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Invoice>> Get()
        {
            return Ok(_invoiceRepository.GetAll());
        }

        /// <summary>
        /// Retrieves an invoice by ID.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Invoice> Get(int id)
        {
            if (id <= 0)
                return BadRequest("ID cannot be negative or zero.");

            var invoice = _invoiceRepository.GetById(id);
            if (invoice == null)
                return NotFound($"Invoice with ID {id} not found.");

            return Ok(invoice);
        }

        /// <summary>
        /// Adds a new invoice.
        /// </summary>
        [HttpPost]
        public ActionResult<string> Post([FromBody] Invoice invoice)
        {
            if (invoice == null)
                return BadRequest("Invoice cannot be null.");

            var message = _invoiceRepository.Add(invoice);
            return Ok(message);
        }

        /// <summary>
        /// Updates an existing invoice.
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody] Invoice invoice)
        {
            if (id <= 0)
                return BadRequest("ID cannot be negative or zero.");

            if (invoice == null)
                return BadRequest("Invoice cannot be null.");

            invoice.Id = id; // Ensure ID consistency
            var message = _invoiceRepository.Update(invoice);
            return Ok(message);
        }

        /// <summary>
        /// Deletes an invoice by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("ID cannot be negative or zero.");

            var message = _invoiceRepository.Delete(id);
            return Ok(message);
        }
    }
}
