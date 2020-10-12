using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVCEntity.Models;

namespace MVCEntity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            /*
            var cliente = new Cliente() { Nome = "Danilo", Telefone = "11976144154" };
            var db = new Database1();
            db.Clientes.Add(cliente);
            db.SaveChanges();
            */

            //var db = new Database1();
            //var clientes = db.Clientes.Where(c => c.Nome.Contains("D")).ToList();
            //var clientes = db.Clientes.ToList();

            //var clientes = Cliente.Todos();
            //new Cliente() { Nome = "ssss" }.Salvar();

            //db.Database.ExecuteSqlCommand("");

            ViewBag.Clientes = Cliente.Todos();

            var db = new Database1();
            var entryPoint = (from clientes in db.Clientes
                              join pedidos in db.Pedidos on clientes.Id equals pedidos.ClienteId
                              where clientes.Nome.Contains("D")
                              select new
                              {
                                  PedidoId = pedidos.Id,
                                  ClienteNome = clientes.Nome,
                              }).Take(10);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
