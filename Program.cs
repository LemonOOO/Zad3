using Zad3.Data;
using Microsoft.EntityFrameworkCore;
using Zad3.Interfaces;
using Zad3.Services;
using Zad3.Respository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IFizzBuzzService, FizzBuzzService>();
builder.Services.AddTransient<IFizzBuzzRepository, FizzBuzzRepository>();

builder.Services.AddDbContext<FizzBuzzContext>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("Zad5+"),
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    }));
builder.Services.AddMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
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



app.UseAuthorization();
app.UseSession();
app.MapRazorPages();

app.Run();
