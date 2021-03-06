using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Locadora.Data;
using Locadora.Models;

namespace Locadora.Controllers
{
    public class FilmesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FilmesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Filmes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Filme.Include(f => f.Diretor).Include(f => f.Estudio);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Filmes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme.SingleOrDefaultAsync(m => m.Id == id);
            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        // GET: Filmes/Create
        public IActionResult Create()
        {
            ViewData["DiretorId"] = new SelectList(_context.Diretor, "Id", "Id");
            ViewData["EstudioId"] = new SelectList(_context.Estudio, "Id", "Id");
            return View();
        }

        // POST: Filmes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataEstreia,DiretorId,EstudioId,Nome,NumPremios,TwoLetterISOLanguageName,_genero")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filme);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DiretorId"] = new SelectList(_context.Diretor, "Id", "Id", filme.DiretorId);
            ViewData["EstudioId"] = new SelectList(_context.Estudio, "Id", "Id", filme.EstudioId);
            return View(filme);
        }

        // GET: Filmes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme.SingleOrDefaultAsync(m => m.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            ViewData["DiretorId"] = new SelectList(_context.Diretor, "Id", "Id", filme.DiretorId);
            ViewData["EstudioId"] = new SelectList(_context.Estudio, "Id", "Id", filme.EstudioId);
            return View(filme);
        }

        // POST: Filmes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataEstreia,DiretorId,EstudioId,Nome,NumPremios,TwoLetterISOLanguageName,_genero")] Filme filme)
        {
            if (id != filme.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmeExists(filme.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["DiretorId"] = new SelectList(_context.Diretor, "Id", "Id", filme.DiretorId);
            ViewData["EstudioId"] = new SelectList(_context.Estudio, "Id", "Id", filme.EstudioId);
            return View(filme);
        }

        // GET: Filmes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme.SingleOrDefaultAsync(m => m.Id == id);
            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filme = await _context.Filme.SingleOrDefaultAsync(m => m.Id == id);
            _context.Filme.Remove(filme);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FilmeExists(int id)
        {
            return _context.Filme.Any(e => e.Id == id);
        }

        //public IActionResult FilmesPorGenero()
        //{
        //    //var q = (from f in _context.Filme
        //    //       group f by f._genero into d
        //    //     select d);
        //    var grouped = _context.Filme.GroupBy(u => u._genero).Select(t =>  new List<Filme>(t));
        //    return View("Index", grouped.ToList());
        //}
    }
}
