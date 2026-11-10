using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ServerApp;
using ServerApp.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. DbContext з SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. MVC
builder.Services.AddControllersWithViews();

// 3. JWT-аутентифікація
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = AuthSettings.Issuer,
            ValidAudience = AuthSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthSettings.Key)),
            ClockSkew = TimeSpan.Zero
        };

        options.Events = new JwtBearerEvents
        {
            // беремо токен з cookie "jwt" (якщо cookie немає, залишається заголовок Authorization)
            OnMessageReceived = ctx =>
            {
                if (ctx.Request.Cookies.TryGetValue("jwt", out var token))
                    ctx.Token = token;
                return Task.CompletedTask;
            },
            // неавторизованих відправляємо на сторінку логіну (для /api лишається 401)
            OnChallenge = ctx =>
            {
                if (!ctx.Request.Path.StartsWithSegments("/api"))
                {
                    ctx.HandleResponse();
                    ctx.Response.Redirect("/Auth/Login");
                }
                return Task.CompletedTask;
            }
        };
    });

// 4. Авторизація ([Authorize])
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();   // ВАЖЛИВО: перед UseAuthorization
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();