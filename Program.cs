using System.Text;
using EmployeeManagement.Context;
using EmployeeManagement.Helper;
using EmployeeManagement.models.ApplicationUserTables;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("Security")["Key"] ?? string.Empty)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddTransient<Initializer>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();