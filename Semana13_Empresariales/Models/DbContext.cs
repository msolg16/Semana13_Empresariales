using Microsoft.EntityFrameworkCore;
using Semana13_Empresariales.Models;

namespace Semana13_Empresariales.Models
{
    public class CompanyContext : DbContext
    {
        public DbSet<Costumer> Costumers { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=LAB1504-13\\SQLEXPRESS;" +
                "Initial Catalog=CompanyDB;" +
                "User Id=msoles;" +
                "Password=123456; " +
                "trustservercertificate=True"
                );
        }
    }
}
