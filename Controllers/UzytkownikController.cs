using Biblioteka.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteka.Models;

namespace Biblioteka.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UzytkownikController : Controller
    {
        private readonly BibliotekaDbContext _contex;
        private readonly UserManager<Uzytkownik> _userManager;
        private readonly IUserStore<Uzytkownik> _userStore;
        private readonly IUserEmailStore<Uzytkownik> _emailStore;
        private readonly ILogger<UzytkownikController> _logger;

        public UzytkownikController(UserManager<Uzytkownik> userManager, BibliotekaDbContext contex,
            IUserStore<Uzytkownik> userStore, ILogger<UzytkownikController> logger)
        {
            _userManager = userManager;
            _contex = contex;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _logger = logger;
            _logger = logger;
        }

        public ActionResult Index()
        {
            return View(_contex.Uzytkownicy.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Uzytkownik user)
        {
            var User = CreateUser();
            User.imie = user.imie;
            User.nazwisko = user.nazwisko;
            User.data_urodzenia = user.data_urodzenia;
            User.rodzaj = "User";
            User.email = user.email;
            User.haslo = user.haslo;

            var result = await _userManager.CreateAsync(User, "User123!");
            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");
                await _userManager.AddToRoleAsync(User, User.rodzaj);
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }


            return View();
        }

        public async Task<ActionResult> Details(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            return View(user);
        }


        // GET: UzytkownikController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return View(user);
        }

        // POST: UzytkownikController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Uzytkownik user)
        {
            try
            {
                var findUser = _contex.Uzytkownicy.FirstOrDefault(u => u.id_uzytkownik == user.id_uzytkownik);
                findUser.imie = user.imie;
                findUser.nazwisko = user.nazwisko;
                findUser.data_urodzenia = user.data_urodzenia;
                findUser.rodzaj = "User";
                findUser.email = user.email;
                findUser.haslo = user.haslo;
                _contex.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UzytkownikController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return View(user);
        }

        // POST: UzytkownikController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Uzytkownik user)
        {
            try
            {
                var findUser = _contex.Uzytkownicy.FirstOrDefault(u => u.id_uzytkownik == user.id_uzytkownik);
                _contex.Uzytkownicy.Remove(findUser);
                _contex.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private IUserEmailStore<Uzytkownik> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }

            return (IUserEmailStore<Uzytkownik>)_userStore;
        }

        private Uzytkownik CreateUser()
        {
            try
            {
                return Activator.CreateInstance<Uzytkownik>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Uzytkownik)}'. " +
                                                    $"Ensure that '{nameof(Uzytkownik)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                                                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
    }
}