using Biblioteka.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
// Dodaj DbContext
builder.Services.AddDbContext<BibliotekaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connectionstr")));
builder.Services.AddIdentityCore<IdentityUser>()
    .AddEntityFrameworkStores<BibliotekaDbContext>()
    .AddApiEndpoints();
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<BibliotekaDbContext>()
.AddRoles<IdentityRole>()
.AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var roleManager =
        scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Admin", "User" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}
using (var scope = app.Services.CreateScope())
{
    var userManager =
        scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    string email = "admin@admin.com";
    string password = "Test123.";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new IdentityUser();
        user.UserName = email;
        user.Email = email;

        await userManager.CreateAsync(user, password);

        await userManager.AddToRoleAsync(user, "Admin");
    }
}
using (var scope = app.Services.CreateScope())
{
    var userManager =
        scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    string email = "user@user.com";
    string password = "Test123.";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new IdentityUser();
        user.UserName = email;
        user.Email = email;

        await userManager.CreateAsync(user, password);

        await userManager.AddToRoleAsync(user, "User");
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}


app.MapIdentityApi<IdentityUser>();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Biblioteka}/{action=Index}/{id?}");

app.Run();
