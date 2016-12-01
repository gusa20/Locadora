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
    public class DiretorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiretorsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Diretors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Diretor.ToListAsync());
        }

        // GET: Diretors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diretor = await _context.Diretor.SingleOrDefaultAsync(m => m.Id == id);
            if (diretor == null)
            {
                return NotFound();
            }

            return View(diretor);
        }

        // GET: Diretors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Diretors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataPrimeiroFilme,DataUltimoFilme,Nome,NumPremios")] Diretor diretor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diretor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(diretor);
        }

        // GET: Diretors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diretor = await _context.Diretor.SingleOrDefaultAsync(m => m.Id == id);
            if (diretor == null)
            {
                return NotFound();
            }
            return View(diretor);
        }

        // POST: Diretors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataPrimeiroFilme,DataUltimoFilme,Nome,NumPremios")] Diretor diretor)
        {
            if (id != diretor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diretor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiretorExists(diretor.Id))
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
            return View(diretor);
        }

        // GET: Diretors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diretor = await _context.Diretor.SingleOrDefaultAsync(m => m.Id == id);
            if (diretor == null)
            {
                return NotFound();
            }

            return View(diretor);
        }

        // POST: Diretors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diretor = await _context.Diretor.SingleOrDefaultAsync(m => m.Id == id);
            _context.Diretor.Remove(diretor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DiretorExists(int id)
        {
            return _context.Diretor.Any(e => e.Id == id);
        }
    }
}
