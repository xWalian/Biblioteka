using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Models
{
    public class BibliotekaDbContext : DbContext
    {
        public BibliotekaDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Ksiazka> Ksiazki { get; set; }
    }
}
