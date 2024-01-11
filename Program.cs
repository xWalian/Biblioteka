using Biblioteka.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Dodaj DbContext
builder.Services.AddDbContext<BibliotekaDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("connectionstr")));
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Konfiguracja middleware'ów
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}



app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
