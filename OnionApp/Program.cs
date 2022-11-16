using OnionApp.Domain.Interfaces;
using OnionApp.Infrastructure.Data;
using OnionApp.Services.Interfaces;
using OnionApp.Infrastructure.Business;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Dependency Injection
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IOrder, CacheOrder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
