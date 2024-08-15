using EmployeeManagement.Context;
using EmployeeManagement.Helper;
using EmployeeManagement.models.ApplicationUserTables;
using EmployeeManagement.Service;
using EmployeeManagement.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// My codes
var connectionString = builder.Configuration.GetConnectionString("Dev");
builder.Services.AddDbContext<MyIdentityDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    
    PasswordOptions passwordOptions = new PasswordOptions()
    {
        RequiredLength = 12,
        RequireNonAlphanumeric = false,
        RequireDigit = false,
        RequireLowercase = false,
        RequireUppercase = false,
        RequiredUniqueChars = 0
    };
    options.Password = passwordOptions;
}).AddRoles<IdentityRole>().AddEntityFrameworkStores<MyIdentityDbContext>();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(builder.Configuration.GetConnectionString("Syncfusion"));
builder.Services.Configure<JwtSection>(builder.Configuration.GetSection("Security"));
builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});
builder.Services.AddAuthorization();
builder.Services.AddTransient<Initializer>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJobService, JobService>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    await service.SeedDataAsync();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapRazorPages();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();