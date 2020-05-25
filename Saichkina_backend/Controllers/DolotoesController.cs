using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Saichkina_backend.Models;
using Microsoft.AspNetCore.Authorization;

namespace Saichkina_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DolotoesController : ControllerBase
    {
        private readonly TodoContext _context;

        public DolotoesController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Dolotoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doloto>>> Getdb_pdolotos()
        {
            return await _context.Dolotoes.ToListAsync();
        }

        // GET: api/Dolotoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doloto>> GetDoloto(int id)
        {
            var doloto = await _context.Dolotoes.FindAsync(id);

            if (doloto == null)
            {
                return NotFound();
            }

            return doloto;
        }

        [HttpGet("threeCone")]
        public async Task<ActionResult<IEnumerable<Doloto>>> GetPlotnichiyDoloto()
         {
            return _context.GetPlotnichiyDoloto(_context.Dolotoes).ToList();
        }

        [HttpGet("{id}/count")]
        public async Task<ActionResult<int>> GetTotalDolotoes(long id)
        {
            var doloto = await _context.Dolotoes.FindAsync(id);

            if (doloto == null)
            {
                return NotFound();
            }

            return doloto.GetCountOfDolotoes();
        }
        // PUT: api/Dolotoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoloto(int id, Doloto doloto)
        {
            if (id != doloto.Id)
            {
                return BadRequest();
            }

            _context.Entry(doloto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DolotoExists(id))
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

        // POST: api/Dolotoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Doloto>> PostDoloto(Doloto doloto)
        {
                _context.Dolotoes.Add(doloto);
                await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDoloto), new { id = doloto.Id }, doloto);
        }

        // DELETE: api/Dolotoes/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Doloto>> DeleteDoloto(int id)
        {
            var doloto = await _context.Dolotoes.FindAsync(id);
            if (doloto == null)
            {
                return NotFound();
            }

            _context.Dolotoes.Remove(doloto);
            await _context.SaveChangesAsync();

            return doloto;
        }

        private bool DolotoExists(int id)
        {
            return _context.Dolotoes.Any(e => e.Id == id);
        }
    }
}
