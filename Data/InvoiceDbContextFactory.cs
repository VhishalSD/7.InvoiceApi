using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InvoiceApp.EFCore.Data
{
    
    public class InvoiceDbContextFactory : IDesignTimeDbContextFactory<InvoiceDbContext>
    {
        public InvoiceDbContext CreateDbContext(string[] args)
        {
            var dbPath = Path.Combine(AppContext.BaseDirectory, "invoices.db");

            var optionsBuilder = new DbContextOptionsBuilder<InvoiceDbContext>();
            optionsBuilder.UseSqlite($"Data Source={dbPath}");

            return new InvoiceDbContext(optionsBuilder.Options);
        }
    }
}
