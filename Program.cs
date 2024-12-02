using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BookLibraryApp.Data;
using BookLibraryApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization(); // Register Authorization Services

var app = builder.Build();

// Call the seeder during application startup
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    DataSeeder.Seed(context);
}

// Call the seeders during application startup
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    UserRoleSeeder.Seed(userManager, roleManager);
}

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication(); // Ensure Authentication middleware is added
app.UseAuthorization();  // Ensure Authorization middleware is added

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=Index}/{id?}");

app.Run();
