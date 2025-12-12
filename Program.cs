using GitDemoToDoApp.Data;
using GitDemoToDoApp.Filters;
using GitDemoToDoApp.Repositories;
using GitDemoToDoApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Service pour la session
builder.Services.AddSession();

// Service pour in-memory database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("TodoDb"));

// Services d'authentification
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Services des todos
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

// Enregistrement des filtres
builder.Services.AddScoped<AuthFilter>();
builder.Services.AddScoped<ThemeFilter>();

// Ajout du filtre global d'authentification (si grande application et beaucoup de controlleurs)
/*
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AuthFilter());
});
*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// S'assurer que la base de données est créée et que les seed data sont appliquées
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
