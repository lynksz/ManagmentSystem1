using Microsoft.EntityFrameworkCore;
using ServerApp.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Додаємо DbContext з підключенням до SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Додаємо підтримку MVC (Controllers + Views)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 3. Налаштування маршрутизації та статичних файлів
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();