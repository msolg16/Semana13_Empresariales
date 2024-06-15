using Microsoft.EntityFrameworkCore;
using Semana13_Empresariales.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semana13_Empresariales.Repositories
{
    public class CustomerRepository
    {
        private readonly CompanyContext _context;

        public CustomerRepository(CompanyContext context)
        {
            _context = context;
        }

        public async Task<List<Costumer>> GetAllCustomersAsync()
        {
            return await _context.Costumers.ToListAsync();
        }

        public async Task<Costumer> GetCustomerByIdAsync(int id)
        {
            return await _context.Costumers.FindAsync(id);
        }

        public async Task CreateCustomerAsync(Costumer customer)
        {
            _context.Costumers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Costumer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _context.Costumers.FindAsync(id);
            if (customer != null)
            {
                customer.IsDeleted = true;  // Marcamos como eliminado lógico
                await _context.SaveChangesAsync();
            }
        }
    }
}
