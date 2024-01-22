using Microsoft.AspNetCore.Mvc;
using Biblioteka.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
                        ilosc = ksiazka.ilosc,
                        CzyWypozyczona = czyUzytkownikWypozyczyl(ksiazka.id_ksiazka)
                    };
                    ksiazkiList.Add(KsiazkiViewModel);
                }
                return View(ksiazkiList);
            }
            return View("");
        }
        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult Wypozycz(int id)
        {
            
            var ksiazka = _context.Ksiazki.Find(id);
            
            if (ksiazka != null && ksiazka.ilosc > 0)
            {

                var wypozyczenie = new Wypozyczenia
                {
                    id_ksiazka = ksiazka.id_ksiazka, 
                    id_uzytkownik = User.FindFirstValue(ClaimTypes.NameIdentifier),
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
        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult Zwroc(int id)
        {
            // Sprawdź, czy użytkownik ma wypożyczoną daną książkę
            if (!czyUzytkownikWypozyczyl(id))
            {
                return NotFound(); // Jeśli użytkownik nie ma wypożyczonej książki, zwróć 404
            }

            var wypozyczenie = _context.Wypozyczenia.FirstOrDefault(w => w.id_ksiazka == id && w.id_uzytkownik == User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (wypozyczenie != null)
            {
                // Zwiększ ilość dostępnych egzemplarzy książki
                var ksiazka = _context.Ksiazki.Find(id);
                ksiazka.ilosc += 1;

                // Usuń rekord wypożyczenia z bazy danych
                _context.Wypozyczenia.Remove(wypozyczenie);

                _context.SaveChanges();
            }

            return RedirectToAction("Ksiazki");
        }

        [HttpGet]
        public IActionResult Szukaj(string searchTerm)
        {
            // Validate if the search term is not null or empty
            if (string.IsNullOrEmpty(searchTerm))
            {
                // If search term is empty, redirect to the Ksiazki action
                return RedirectToAction("Ksiazki");
            }

            var lowerSearchTerm = searchTerm.ToLower();

            // Perform case-insensitive search in the database using ToLower()
            var matchedKsiazki = _context.Ksiazki
                .Where(k => k.tytul.ToLower().Contains(lowerSearchTerm) ||
                            k.autor.ToLower().Contains(lowerSearchTerm) ||
                            k.wydawnictwo.ToLower().Contains(lowerSearchTerm))
                .ToList();

            // Convert matched books to view models
            List<KsiazkaViewModel> matchedKsiazkiList = matchedKsiazki.Select(ksiazka => new KsiazkaViewModel
            {
                id_ksiazka = ksiazka.id_ksiazka,
                autor = ksiazka.autor,
                tytul = ksiazka.tytul,
                wydawnictwo = ksiazka.wydawnictwo,
                rok_wydania = ksiazka.rok_wydania,
                ilosc = ksiazka.ilosc
            }).ToList();

            // Pass the matched books to the view
            return View("Ksiazki", matchedKsiazkiList);

        }
        [HttpGet]
        public IActionResult Edytuj(int id)
        {
            var ksiazka = _context.Ksiazki.Find(id);

            if (ksiazka == null)
            {
                return NotFound(); // Jeśli nie znaleziono książki, zwróć 404
            }

            var viewModel = new KsiazkaViewModel
            {
                id_ksiazka = ksiazka.id_ksiazka,
                id_kategoria = ksiazka.id_kategoria,
                autor = ksiazka.autor,
                tytul = ksiazka.tytul,
                wydawnictwo = ksiazka.wydawnictwo,
                rok_wydania = ksiazka.rok_wydania,
                ilosc = ksiazka.ilosc
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edytuj(KsiazkaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var ksiazka = _context.Ksiazki.Find(viewModel.id_ksiazka);

                if (ksiazka == null)
                {
                    return NotFound(); // Jeśli nie znaleziono książki, zwróć 404
                }

                ksiazka.id_kategoria = viewModel.id_kategoria;
                ksiazka.autor = viewModel.autor;
                ksiazka.tytul = viewModel.tytul;
                ksiazka.wydawnictwo = viewModel.wydawnictwo;
                ksiazka.rok_wydania = viewModel.rok_wydania;
                ksiazka.ilosc = viewModel.ilosc;

                _context.SaveChanges();

                return RedirectToAction("Ksiazki");
            }

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Usun(int id)
        {
            // Pobierz książkę do usunięcia na podstawie identyfikatora
            var ksiazka = _context.Ksiazki.Find(id);

            if (ksiazka == null)
            {
                return NotFound(); // Jeśli nie znaleziono książki, zwróć 404
            }

            // Usuń książkę z kontekstu bazy danych
            _context.Ksiazki.Remove(ksiazka);
            _context.SaveChanges();

            return RedirectToAction("Ksiazki");
        }

        [HttpGet]
        public IActionResult Dodaj()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Dodaj(KsiazkaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Tworzymy nowy obiekt Ksiazka na podstawie danych z formularza
                var nowaKsiazka = new Ksiazka
                {
                    id_kategoria = viewModel.id_kategoria,
                    autor = viewModel.autor,
                    tytul = viewModel.tytul,
                    wydawnictwo = viewModel.wydawnictwo,
                    rok_wydania = viewModel.rok_wydania,
                    ilosc = viewModel.ilosc
                };

                // Dodajemy nową książkę do kontekstu bazy danych
                _context.Ksiazki.Add(nowaKsiazka);
                _context.SaveChanges();

                return RedirectToAction("Ksiazki");
            }

            return View(viewModel);
        }

        public bool czyUzytkownikWypozyczyl(int idKsiazki)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                // Sprawdź, czy użytkownik wypożyczył już daną książkę
                return _context.Wypozyczenia.Any(w => w.id_ksiazka == idKsiazki && w.id_uzytkownik == userId);
            }

            return false;
        }


    }

}
