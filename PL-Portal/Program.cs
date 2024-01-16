using Data.DbInitializer;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PL_Portal.Controllers;
using PL_Portal.Data;
using Services.ArticleService;
using Services.MaterialService;
using Data.Generic_interface;
using Data.Models;
using Services.BookService;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("PL_PortalContext");
builder.Services.AddDbContext<PortalContext>(options =>
    options.UseSqlServer(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
   .AddEntityFrameworkStores<PortalContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization();
builder.Services.AddFluentValidation();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IRepository<Article>, Repository<Article>>();
builder.Services.AddScoped<IRepository<Book>, Repository<Book>>();
builder.Services.AddScoped<IRepository<Video>, Repository<Video>>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=books}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
