/*using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Biblioteka.Models;

namespace Biblioteka.Models;

public class ApplicationDBContext : IdentityDbContext<Uzytkownik>
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {    }
    public DbSet<Uzytkownik> Uzytkownicy { get; set; }
    private class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<Uzytkownik>
    {
        public void Configure(EntityTypeBuilder<Uzytkownik> builder)
        {
            builder.Property(x => x.imie).HasMaxLength(20);
            builder.Property(x => x.nazwisko).HasMaxLength(20);
            builder.Property(x => x.email).HasMaxLength(20);
        }
    }
}*/