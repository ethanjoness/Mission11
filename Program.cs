using Microsoft.EntityFrameworkCore;
using BookstoreApp.Data;
using BookstoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); 

builder.Services.AddDbContext<BookstoreContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BookstoreConnection")));

builder.Services.AddScoped<IBookstoreRepository, EFBookstoreRepository>();

// Setup for Session and Cart
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        builder => builder.WithOrigins("http://localhost:3000") // Default React port
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

app.UseStaticFiles();
app.UseSession(); 
app.UseRouting();

app.UseCors("AllowReact");

// Clean Routing Pattern
app.MapControllerRoute("catpage", "{category}/Page{pageNum:int}", new { Controller = "Home", Action = "Index" });
app.MapControllerRoute("page", "Page{pageNum:int}", new { Controller = "Home", Action = "Index", pageNum = 1 });
app.MapControllerRoute("category", "{category}", new { Controller = "Home", Action = "Index", pageNum = 1 });
app.MapDefaultControllerRoute();

app.MapRazorPages(); 

app.Run();