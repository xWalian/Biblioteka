using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class BibliotekaDbContext : IdentityDbContext<IdentityUser>
    {
        public BibliotekaDbContext(DbContextOptions<BibliotekaDbContext> options) : base(options)
        {

        }
        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }

        public DbSet<Ksiazka> Ksiazki { get; set; }
        public DbSet<Wypozyczenia> Wypozyczenia { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ksiazka>().HasData(
                new Ksiazka { id_ksiazka = 1, id_kategoria = 4, autor = "J.R.R. Tolkien", tytul = "Władca Pierścieni", wydawnictwo = "Wydawnictwo Amber", rok_wydania = 1955, ilosc = 12 },
                new Ksiazka { id_ksiazka = 2, id_kategoria = 1, autor = "J.K. Rowling", tytul = "Harry Potter i Kamień Filozoficzny", wydawnictwo = "Media Rodzina", rok_wydania = 1997, ilosc = 7 },
                new Ksiazka { id_ksiazka = 3, id_kategoria = 4, autor = "Stanisław Lem", tytul = "Solaris", wydawnictwo = "Czytelnik", rok_wydania = 1961, ilosc = 5 },
                new Ksiazka { id_ksiazka = 4, id_kategoria = 1, autor = "Michaił Bułhakow", tytul = "Mistrz i Małgorzata", wydawnictwo = "Czytelnik", rok_wydania = 1966, ilosc = 8 },
                new Ksiazka { id_ksiazka = 5, id_kategoria = 4, autor = "Jacek Dukaj", tytul = "Zdobywcy księżyca", wydawnictwo = "Wydawnictwo Literackie", rok_wydania = 2003, ilosc = 10 },
                new Ksiazka { id_ksiazka = 6, id_kategoria = 2, autor = "Jane Austen", tytul = "Duma i uprzedzenie", wydawnictwo = "Znak", rok_wydania = 1813, ilosc = 3 },
                new Ksiazka { id_ksiazka = 7, id_kategoria = 2, autor = "Jane Austen", tytul = "Rozważna i romantyczna", wydawnictwo = "Znak", rok_wydania = 1811, ilosc = 15 },
                new Ksiazka { id_ksiazka = 8, id_kategoria = 3, autor = "D.H. Lawrence", tytul = "Kochanek Lady Chatterley", wydawnictwo = "Zysk i S-ka", rok_wydania = 1928, ilosc = 6 },
                new Ksiazka { id_ksiazka = 9, id_kategoria = 2, autor = "Gabriel Garcia Marquez", tytul = "Miłość w czasach zarazy", wydawnictwo = "Znak", rok_wydania = 1985, ilosc = 4 },
                new Ksiazka { id_ksiazka = 10, id_kategoria = 2, autor = "Erich Maria Remarque", tytul = "Pożegnanie z Marią", wydawnictwo = "Czytelnik", rok_wydania = 1929, ilosc = 9 },
                new Ksiazka { id_ksiazka = 11, id_kategoria = 3, autor = "Agatha Christie", tytul = "Zabójstwo Rogera Ackroyda", wydawnictwo = "Czarna Owca", rok_wydania = 1926, ilosc = 11 },
                new Ksiazka { id_ksiazka = 12, id_kategoria = 3, autor = "Markus Zusak", tytul = "Złodziejka książek", wydawnictwo = "Czarna Owca", rok_wydania = 2005, ilosc = 14 },
                new Ksiazka { id_ksiazka = 13, id_kategoria = 3, autor = "Agatha Christie", tytul = "Człowiek z laską", wydawnictwo = "Czytelnik", rok_wydania = 1937, ilosc = 7 },
                new Ksiazka { id_ksiazka = 14, id_kategoria = 3, autor = "Agatha Christie", tytul = "Zabójstwo w Orient Expressie", wydawnictwo = "Czytelnik", rok_wydania = 1934, ilosc = 8 },
                new Ksiazka { id_ksiazka = 15, id_kategoria = 2, autor = "Charles Dickens", tytul = "Klub Pickwicka", wydawnictwo = "Znak", rok_wydania = 1837, ilosc = 2 },
                new Ksiazka { id_ksiazka = 16, id_kategoria = 4, autor = "Philip K. Dick", tytul = "Raport mniejszości", wydawnictwo = "Czytelnik", rok_wydania = 1956, ilosc = 6 },
                new Ksiazka { id_ksiazka = 17, id_kategoria = 4, autor = "William Gibson", tytul = "Neuromancer", wydawnictwo = "Prószyński i S-ka", rok_wydania = 1984, ilosc = 9 },
                new Ksiazka { id_ksiazka = 18, id_kategoria = 4, autor = "Isaac Asimov", tytul = "Fundacja", wydawnictwo = "Zysk i S-ka", rok_wydania = 1951, ilosc = 13 },
                new Ksiazka { id_ksiazka = 19, id_kategoria = 4, autor = "Albert Camus", tytul = "Dżuma", wydawnictwo = "Czytelnik", rok_wydania = 1947, ilosc = 10 },
                new Ksiazka { id_ksiazka = 20, id_kategoria = 4, autor = "Dmitrij Gluchowski", tytul = "Metro 2033", wydawnictwo = "Insignis Media", rok_wydania = 2005, ilosc = 7 },
                new Ksiazka { id_ksiazka = 21, id_kategoria = 5, autor = "Walter Isaacson", tytul = "Steve Jobs", wydawnictwo = "Znak", rok_wydania = 2011, ilosc = 5 },
                new Ksiazka { id_ksiazka = 22, id_kategoria = 5, autor = "Stanisław Lem", tytul = "Moi przyjaciele", wydawnictwo = "Literackie", rok_wydania = 2007, ilosc = 3 },
                new Ksiazka { id_ksiazka = 23, id_kategoria = 5, autor = "Lech Wałęsa", tytul = "Kochanek", wydawnictwo = "Iskry", rok_wydania = 2007, ilosc = 8 },
                new Ksiazka { id_ksiazka = 24, id_kategoria = 5, autor = "Anne Frank", tytul = "Dziennik Anne Frank", wydawnictwo = "Czytelnik", rok_wydania = 1947, ilosc = 4 },
                new Ksiazka { id_ksiazka = 25, id_kategoria = 5, autor = "Aleksander Wat", tytul = "Mój wiek", wydawnictwo = "Czytelnik", rok_wydania = 1968, ilosc = 12 },
                new Ksiazka { id_ksiazka = 26, id_kategoria = 6, autor = "Antony Beevor", tytul = "Stalingrad", wydawnictwo = "Zysk i S-ka", rok_wydania = 1998, ilosc = 15 },
                new Ksiazka { id_ksiazka = 27, id_kategoria = 6, autor = "Yuval Noah Harari", tytul = "Sapiens: Krótka historia ludzkości", wydawnictwo = "Wydawnictwo Literackie", rok_wydania = 2011, ilosc = 10 },
                new Ksiazka { id_ksiazka = 28, id_kategoria = 6, autor = "Joseph Bédier", tytul = "Dzieje Tristana i Izoldy", wydawnictwo = "Ossolineum", rok_wydania = 1900, ilosc = 11 },
                new Ksiazka { id_ksiazka = 29, id_kategoria = 6, autor = "Ken Follett", tytul = "Upadek gigantów", wydawnictwo = "Wydawnictwo Znak", rok_wydania = 2010, ilosc = 6 },
                new Ksiazka { id_ksiazka = 30, id_kategoria = 6, autor = "Henryk Sienkiewicz", tytul = "W pustyni i w puszczy", wydawnictwo = "Ossolineum", rok_wydania = 1911, ilosc = 8 }
            );
        }


    }
}
