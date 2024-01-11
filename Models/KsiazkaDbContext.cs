using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Models
{
    public class KsiazkaDbContext : DbContext
    {
        public KsiazkaDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Ksiazka> ksiazki { get; set; }
    }
}
