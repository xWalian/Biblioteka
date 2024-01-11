using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Biblioteka.Models;
namespace Biblioteka.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BibliotekaDbContext _context;



        public HomeController(ILogger<HomeController> logger, BibliotekaDbContext ksiazkaDbContext)
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



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
