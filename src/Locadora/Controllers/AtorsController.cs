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
    public class AtorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AtorsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Ators
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ator.ToListAsync());
        }

        // GET: Ators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ator = await _context.Ator.SingleOrDefaultAsync(m => m.Id == id);
            if (ator == null)
            {
                return NotFound();
            }

            return View(ator);
        }

        // GET: Ators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataPrimeiroFilme,DataUltimoFilme,Nome,NumPremios")] Ator ator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ator);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ator);
        }

        // GET: Ators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ator = await _context.Ator.SingleOrDefaultAsync(m => m.Id == id);
            if (ator == null)
            {
                return NotFound();
            }
            return View(ator);
        }

        // POST: Ators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataPrimeiroFilme,DataUltimoFilme,Nome,NumPremios")] Ator ator)
        {
            if (id != ator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtorExists(ator.Id))
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
            return View(ator);
        }

        // GET: Ators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ator = await _context.Ator.SingleOrDefaultAsync(m => m.Id == id);
            if (ator == null)
            {
                return NotFound();
            }

            return View(ator);
        }

        // POST: Ators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ator = await _context.Ator.SingleOrDefaultAsync(m => m.Id == id);
            _context.Ator.Remove(ator);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AtorExists(int id)
        {
            return _context.Ator.Any(e => e.Id == id);
        }
    }
}
