using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class BibliotekaDbContext : DbContext
    {
        public BibliotekaDbContext(DbContextOptions<BibliotekaDbContext> options) : base(options)
        {

        }
        public DbSet<Ksiazka> Ksiazki { get; set; }
        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<Wypozyczenia> Wypozyczenia { get; set; }

    }
}
