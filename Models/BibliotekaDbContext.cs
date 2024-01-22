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
/*        public DbSet<Uzytkownik> Uzytkownicy { get; set; }*/
        public DbSet<Wypozyczenia> Wypozyczenia { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
