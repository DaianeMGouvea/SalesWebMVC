using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMVC.Data;
using SalesWebMVC.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);


string mySqlConnection = builder.Configuration.GetConnectionString("SalesWebMVCContext");

builder.Services.AddDbContextPool<SalesWebMVCContext>(options => options.UseMySql(mySqlConnection,
                      ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddScoped<SeedingService>();
builder.Services.AddTransient<SellerService>();
builder.Services.AddScoped<DepartmentService>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var enUS = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions 
{ 
    DefaultRequestCulture = new RequestCulture(enUS),
    SupportedCultures = new List<CultureInfo> {enUS},
    SupportedUICultures = new List<CultureInfo> {enUS},
};

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseRequestLocalization(localizationOptions);

if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    SeedDatabase();
}

void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
        seedingService.Seed();
    }
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
