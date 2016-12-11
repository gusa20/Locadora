using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Locadora.Data;
using Locadora.Models;

namespace Locadora.Controllers
{
    [Produces("application/json")]
    [Route("api/Filmes")]
    public class FilmesAPIController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FilmesAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Filmes
        [HttpGet]
        public IEnumerable<Filme> GetFilme()
        {
            return _context.Filme;
        }

        // GET: api/Filmes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilme([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Filme filme = await _context.Filme.SingleOrDefaultAsync(m => m.Id == id);

            if (filme == null)
            {
                return NotFound();
            }

            return Ok(filme);
        }

        // PUT: api/Filmes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilme([FromRoute] int id, [FromBody] Filme filme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != filme.Id)
            {
                return BadRequest();
            }

            _context.Entry(filme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmeExists(id))
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

        // POST: api/Filmes
        [HttpPost]
        public async Task<IActionResult> PostFilme([FromBody] Filme filme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Filme.Add(filme);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FilmeExists(filme.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFilme", new { id = filme.Id }, filme);
        }

        // DELETE: api/Filmes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilme([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Filme filme = await _context.Filme.SingleOrDefaultAsync(m => m.Id == id);
            if (filme == null)
            {
                return NotFound();
            }

            _context.Filme.Remove(filme);
            await _context.SaveChangesAsync();

            return Ok(filme);
        }

        private bool FilmeExists(int id)
        {
            return _context.Filme.Any(e => e.Id == id);
        }
    }
}