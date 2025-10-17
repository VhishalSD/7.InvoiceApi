using InvoiceApi.Repositories;
using InvoiceApp.EFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApi
{
    /// <summary>
    /// Main entry point for the Invoice API application.
    /// Configures services, database, and HTTP request pipeline.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry method.
        /// </summary>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register repositories
            builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            builder.Services.AddScoped<IInvoiceItemRepository, InvoiceItemRepository>();

            // Configure SQLite database
            var dbPath = Path.Combine(AppContext.BaseDirectory, "invoices.db");
            builder.Services.AddDbContext<InvoiceDbContext>(options =>
                options.UseSqlite($"Data Source={dbPath}"));

            var app = builder.Build();

            // Configure HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
