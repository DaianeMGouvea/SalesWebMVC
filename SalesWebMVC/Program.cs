using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMVC.Data;
using SalesWebMVC.Services;

var builder = WebApplication.CreateBuilder(args);


string mySqlConnection = builder.Configuration.GetConnectionString("SalesWebMVCContext");

builder.Services.AddDbContextPool<SalesWebMVCContext>(options => options.UseMySql(mySqlConnection,
                      ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddScoped<SeedingService>();
builder.Services.AddTransient<SellerService>();
builder.Services.AddScoped<DepartmentService>();


// Add services to the container.
builder.Services.AddControllersWithViews();



var app = builder.Build();
// Configure the HTTP request pipeline.


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
