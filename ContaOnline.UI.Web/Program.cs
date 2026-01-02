using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Adiciona o serviço de autenticação
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.LoginPath = "/Account/Login"; // Caminho da sua tela de login
        //options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });
builder.Services.AddDistributedMemoryCache();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();   
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // tempo de expiração
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;     
});


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=App}/{action=Inicio}/{id?}");

app.Run();
