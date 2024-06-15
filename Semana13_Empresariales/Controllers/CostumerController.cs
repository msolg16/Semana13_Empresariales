// CustomersController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Semana13_Empresariales.Models;
using Semana13_Empresariales.Repositories;

namespace Semana13_Empresariales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CompanyContext _context;

        public CustomersController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Costumer>>> GetCustomers()
        {
            return await _context.Costumers.Where(c => !c.IsDeleted).ToListAsync();
        }

        // GET: api/customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Costumer>> GetCustomer(int id)
        {
            var customer = await _context.Costumers.FindAsync(id);

            if (customer == null || customer.IsDeleted)
            {
                return NotFound();
            }

            return customer;
        }

        // POST: api/customers
        [HttpPost]
        public async Task<ActionResult<Costumer>> PostCustomer(Costumer customer)
        {
            _context.Costumers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.CostumerId }, customer);
        }

        // PUT: api/customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Costumer customer)
        {
            if (id != customer.CostumerId)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Costumers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            // Marcado como eliminado lógico
            customer.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Costumers.Any(e => e.CostumerId == id);
        }
    }
}
