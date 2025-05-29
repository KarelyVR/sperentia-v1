using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sperientia___SGI;
using Sperientia___SGI.Models.dbModels;
using Sperientia___SGI.Models.dbModels.DbContext;
using Sperientia___SGI.Models.Services;
using Sperientia___SGI.Models.Utils.Email;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<SperientiaContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Configuración de requisitos de contraseñas
builder.Services.Configure<IdentityOptions>(options =>
{
    //TODO: Volver a habilitar las contraseñas seguras
    options.Password.RequiredLength = 3;
    options.Password.RequireDigit = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<SperientiaContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Configuraciones de servicios y datos
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IMailService, MailService>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseExceptionHandler("/Home/Error");
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// INITIALIZE DATABASE CONTEXT
using (var scope = app.Services.CreateScope())
{
    var dbcontext = scope.ServiceProvider.GetRequiredService<SperientiaContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
    var webHostEnvironment = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

    await InitializeDbAsync(dbcontext, userManager, roleManager, webHostEnvironment);
}

app.UseHttpsRedirection();

// Importante que esté antes de UseRouting()
app.Use(async (context, next) =>
{
    // Si se accede a la ruta "/" y no esta autenticado redirige al login.
    // Si se accede a la ruta "/" y está autenticado redirige a la página por defecto.
    if (context.Request.Path == "/" && !context.User.Identity?.IsAuthenticated == true)
    {
        //context.Response.Redirect("/Identity/Account/Login");
        //return;

        // Reenviar la solicitud internamente sin cambiar la URL en el navegador
        context.Request.Path = "/Identity/Account/Login";
    }

    await next();
});

// TODO: No lo he probado si causa error borrarlo
app.Use(async (context, next) =>
{
    await next();
    // Si es una petición de error y no es una petición AJAX lo redirigimos a la pantalla de error.
    if (context.Response.StatusCode >= 400 && !context.Request.Headers["X-Requested-With"].Equals("XMLHttpRequest"))
    {
        context.Request.Path = "/Home/Error";
        context.Request.QueryString = new QueryString($"?statusCode={context.Response.StatusCode}");
        await next();
    }
});

app.UseRouting();

app.UseStaticFiles();

app.UseAuthorization();

app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

static async Task InitializeDbAsync(SperientiaContext dbcontext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager, IWebHostEnvironment _webHostEnvironment)
{
    InitDB.TryToMigrate(dbcontext);
    await InitDB.TryCreateDefaultUsersAndRolesAsync(userManager, roleManager);
    await InitDB.TrySeedDefaultDataAsync(dbcontext);
}