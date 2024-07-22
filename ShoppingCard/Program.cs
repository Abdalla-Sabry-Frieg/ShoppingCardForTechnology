using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Infrastructure_.DataBase;
using Domin.Models;
using Infrastructure_.Repository.IRepository;
using Infrastructure_.Repository.RepositoryServices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ShoppingCardDbContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DefultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ShoppingCardDbContext>().AddDefaultTokenProviders();
builder.Services.AddTransient<IUnitOfWork,unitOfWork>();

builder.Services.AddSession();

builder.Services.ConfigureApplicationCookie(option =>
    {
        option.LoginPath = "/Admin/Login/Login";
        option.AccessDeniedPath = "/Admin/Home/Denied";
    });

builder.Services.Configure<IdentityOptions>(options =>
    {
        options.Password.RequiredLength = 5;
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredUniqueChars = 0;
    });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Login}/{action=Login}/{id?}"
    );

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
