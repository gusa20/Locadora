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
    public class MidiasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MidiasController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Midias
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Midia.Include(m => m.Filme);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Midias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var midia = await _context.Midia.SingleOrDefaultAsync(m => m.Id == id);
            if (midia == null)
            {
                return NotFound();
            }

            return View(midia);
        }

        // GET: Midias/Create
        public IActionResult Create()
        {
            ViewData["FilmeId"] = new SelectList(_context.Filme, "Id", "Id");
            return View();
        }

        // POST: Midias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FilmeId,Preco,TwoLetterISOLanguageName,TwoLetterISOSubtitleName")] Midia midia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(midia);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["FilmeId"] = new SelectList(_context.Filme, "Id", "Id", midia.FilmeId);
            return View(midia);
        }

        // GET: Midias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var midia = await _context.Midia.SingleOrDefaultAsync(m => m.Id == id);
            if (midia == null)
            {
                return NotFound();
            }
            ViewData["FilmeId"] = new SelectList(_context.Filme, "Id", "Id", midia.FilmeId);
            return View(midia);
        }

        // POST: Midias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FilmeId,Preco,TwoLetterISOLanguageName,TwoLetterISOSubtitleName")] Midia midia)
        {
            if (id != midia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(midia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MidiaExists(midia.Id))
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
            ViewData["FilmeId"] = new SelectList(_context.Filme, "Id", "Id", midia.FilmeId);
            return View(midia);
        }

        // GET: Midias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var midia = await _context.Midia.SingleOrDefaultAsync(m => m.Id == id);
            if (midia == null)
            {
                return NotFound();
            }

            return View(midia);
        }

        // POST: Midias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var midia = await _context.Midia.SingleOrDefaultAsync(m => m.Id == id);
            _context.Midia.Remove(midia);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MidiaExists(int id)
        {
            return _context.Midia.Any(e => e.Id == id);
        }
    }
}
