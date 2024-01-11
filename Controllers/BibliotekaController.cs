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
        [HttpGet]
        public IActionResult Ksiazki()
        {
            var ksiazki = _context.Ksiazki.ToList();
            List<KsiazkaViewModel> ksiazkiList = new List<KsiazkaViewModel>();
            if (ksiazki != null)
            {

                foreach (var ksiazka in ksiazki)
                {
                    var KsiazkiViewModel = new KsiazkaViewModel()
                    {
                        autor = ksiazka.autor,
                        tytul = ksiazka.tytul,
                        wydawnictwo = ksiazka.wydawnictwo,
                        rok_wydania = ksiazka.rok_wydania,
                        ilosc = ksiazka.ilosc
                    };
                    ksiazkiList.Add(KsiazkiViewModel);
                }
                return View(ksiazkiList);
            }
            return View("");
        }
    }

}
