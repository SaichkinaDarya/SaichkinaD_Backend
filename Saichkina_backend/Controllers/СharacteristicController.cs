using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Saichkina_backend.Models;

namespace Saichkina_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class СharacteristicController : ControllerBase
    {
        private readonly TodoContext _context;

        public СharacteristicController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Сharacteristic
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Сharacteristic>>> Getdb_characteristics()
        {
            return await _context.Characteristics.ToListAsync();
        }

        // GET: api/Сharacteristic/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Сharacteristic>> GetСharacteristic(int id)
        {
            var сharacteristic = await _context.Characteristics.FindAsync(id);

            if (сharacteristic == null)
            {
                return NotFound();
            }

            return сharacteristic;
        }

      
        // PUT: api/Сharacteristic/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutСharacteristic(int id, Сharacteristic сharacteristic)
        {
            if (id != сharacteristic.Id)
            {
                return BadRequest();
            }

            _context.Entry(сharacteristic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!СharacteristicExists(id))
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

        // POST: api/Сharacteristic
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Сharacteristic>> PostСharacteristic(Сharacteristic сharacteristic)
        {
            _context.Characteristics.Add(сharacteristic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetСharacteristic", new { id = сharacteristic.Id }, сharacteristic);
        }

        // DELETE: api/Сharacteristic/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Сharacteristic>> DeleteСharacteristic(int id)
        {
            var сharacteristic = await _context.Characteristics.FindAsync(id);
            if (сharacteristic == null)
            {
                return NotFound();
            }

            _context.Characteristics.Remove(сharacteristic);
            await _context.SaveChangesAsync();

            return сharacteristic;
        }

        private bool СharacteristicExists(int id)
        {
            return _context.Characteristics.Any(e => e.Id == id);
        }
    }
}
