using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Locadora.Data;
using Microsoft.EntityFrameworkCore;
using static Locadora.Models.Emprestimo;

namespace Locadora.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext _ctx { get; set; }
        public HomeController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            CountClientes();
            CountMidias();
            CountMidiasEmprestadas();
            FaturamentoAteUltimaSemana();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        // GET: /CountClientes
        public IActionResult CountClientes()
        {
            var count = (from c in _ctx.Cliente
                         select c.Emprestimos);
            ViewData["count"] = count.Count();

            return View("Index");
        }
        public IActionResult CountMidias()
        {
            var count = (from m in _ctx.Midia
                         select m);
            ViewData["countMidias"] = count.Count();

            return View("Index");
        }
        public IActionResult CountMidiasEmprestadas()
        {
            var q = (from m in _ctx.Midia
                         join e in _ctx.Emprestimo  on m.Id equals e.MidiaId
                         where e._statusEmprestimo == StatusEmprestimo.EmVigor
                         select m);

            ViewData["countMidiasEmprestadas"] = q.Count();

            return View("Index");
        }

        public IActionResult FaturamentoAteUltimaSemana()
        {
            var q = (from m in _ctx.Midia
                     join e in _ctx.Emprestimo on m.Id equals e.MidiaId
                     where e.DataDevolucao.CompareTo(DateTime.Today.AddDays(-7)) >= 0
                     select m);

            ViewData["faturamentoAteUltimaSemana"] = q.Sum(x => x.Preco);

            return View("Index");
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
