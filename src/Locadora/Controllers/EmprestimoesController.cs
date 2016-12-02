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
    public class EmprestimoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmprestimoesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Emprestimoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Emprestimo.Include(e => e.Cliente).Include(e => e.Midia);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Emprestimoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimo.SingleOrDefaultAsync(m => m.Id == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // GET: Emprestimoes/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id");
            ViewData["MidiaId"] = new SelectList(_context.Midia, "Id", "Id");
            return View();
        }

        // POST: Emprestimoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,DataDevolucao,MidiaId,_statusEmprestimo")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emprestimo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", emprestimo.ClienteId);
            ViewData["MidiaId"] = new SelectList(_context.Midia, "Id", "Id", emprestimo.MidiaId);
            return View(emprestimo);
        }

        // GET: Emprestimoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimo.SingleOrDefaultAsync(m => m.Id == id);
            if (emprestimo == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", emprestimo.ClienteId);
            ViewData["MidiaId"] = new SelectList(_context.Midia, "Id", "Id", emprestimo.MidiaId);
            return View(emprestimo);
        }

        // POST: Emprestimoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,DataDevolucao,MidiaId,_statusEmprestimo")] Emprestimo emprestimo)
        {
            if (id != emprestimo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emprestimo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmprestimoExists(emprestimo.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", emprestimo.ClienteId);
            ViewData["MidiaId"] = new SelectList(_context.Midia, "Id", "Id", emprestimo.MidiaId);
            return View(emprestimo);
        }

        // GET: Emprestimoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimo.SingleOrDefaultAsync(m => m.Id == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // POST: Emprestimoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emprestimo = await _context.Emprestimo.SingleOrDefaultAsync(m => m.Id == id);
            _context.Emprestimo.Remove(emprestimo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EmprestimoExists(int id)
        {
            return _context.Emprestimo.Any(e => e.Id == id);
        }
    }
}
