using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Biblioteka.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Biblioteka.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KsiazkaDbContext _context;



        public HomeController(ILogger<HomeController> logger, KsiazkaDbContext ksiazkaDbContext)
        {
            _logger = logger;
            _context = ksiazkaDbContext;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult ListaKsiazek()
        {
            
            var ksiazki = _context.ksiazki.ToList();
            List<KsiazkaViewModel> ksiazkiList = new List<KsiazkaViewModel>();
            if (ksiazki != null)
            {
                foreach (var ksiazka in ksiazki)
                {
                    var KsiazkaViewModel = new KsiazkaViewModel()
                    {
                        autor = ksiazka.autor,
                        tytul = ksiazka.tytul,
                        wydawnictwo = ksiazka.wydawnictwo,
                        rok_wydania = ksiazka.rok_wydania,
                        ilosc = ksiazka.ilosc
                    };
                    ksiazkiList.Add(KsiazkaViewModel);
                }
                return View(ksiazkiList);
            }
            return View();
        }

    }
}
