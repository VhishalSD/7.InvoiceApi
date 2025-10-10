
using InvoiceApi.Repositories;
using InvoiceApp.EFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddScoped<IInvoiceItemRepository, InvoiceItemRepository>();

            // make sure the database file is created in a known location
            var dbPath = Path.Combine(AppContext.BaseDirectory, "invoices.db");

            builder.Services.AddDbContext<InvoiceDbContext>(options =>
                options.UseSqlite($"Data Source={dbPath}"));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
