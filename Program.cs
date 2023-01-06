using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proiect2.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});

// Add services to the container.
builder.Services.AddRazorPages(option =>
{
    option.Conventions.AuthorizeFolder("/Cosmetics");
    option.Conventions.AllowAnonymousToPage("/Cosmetics/Index");
    option.Conventions.AllowAnonymousToPage("/Cosmetics/Details");
    option.Conventions.AuthorizeFolder("/Testers", "AdminPolicy");

});
builder.Services.AddDbContext<Proiect2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect2Context") ?? throw new InvalidOperationException("Connection string 'Proiect2Context' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect2Context") ?? throw new InvalidOperationException("Connectionstring 'Proiect2Context' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
