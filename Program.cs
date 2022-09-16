using static PhoneBook.Models.PhoneBooks;
using PhonBook.Middleware;
using Microsoft.EntityFrameworkCore;
using PhonBook.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IPhonBook, PhoneBookItems>();
builder.Services.AddScoped<IPhoneBookServices, PhoneBookServices>();

builder.Services.AddEntityFrameworkSqlServer().AddDbContext<PhonBook.Context.PhonebookDbContext>(config =>
{config.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    

app.Run();

app.UseMiddleware<Mymiddelware>();
