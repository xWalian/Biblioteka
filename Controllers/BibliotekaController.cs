using Microsoft.AspNetCore.Mvc;
using Biblioteka.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Identity;

namespace Biblioteka.Controllers

{   

    public class BibliotekaController : Controller
    {
        private readonly BibliotekaDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public BibliotekaController(BibliotekaDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
                        id_ksiazka = ksiazka.id_ksiazka,
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

        [HttpPost]
        public IActionResult Wypozycz(int id)
        {
            
            var ksiazka = _context.Ksiazki.Find(id);
            
            if (ksiazka != null && ksiazka.ilosc > 0)
            {

                var wypozyczenie = new Wypozyczenia
                {
                    id_ksiazka = ksiazka.id_ksiazka, 
                    data_wypozyczenia = DateTime.Now,            
                };
                ksiazka.ilosc -= 1;
                _context.Update(ksiazka);
                _context.Wypozyczenia.Add(wypozyczenie);
                _context.SaveChanges();

                return RedirectToAction("Ksiazki");
            }

            return RedirectToAction("Ksiazki");
        }


    }

}
