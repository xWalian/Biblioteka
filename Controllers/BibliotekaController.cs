using Microsoft.AspNetCore.Mvc;
using Biblioteka.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Biblioteka.Controllers

{
    public class BibliotekaController : Controller
    {
        private readonly BibliotekaDbContext _context;
        public BibliotekaController(BibliotekaDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index() {
            return View();
        }
        public IActionResult Ksiazki()
        {
            return View();
        }
    }

}
