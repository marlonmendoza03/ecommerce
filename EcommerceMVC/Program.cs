using Microsoft.EntityFrameworkCore;
using Repository.Commands;
using Repository.DataContext;
using Repository.Interfaces;
using Repository.Queries;
using Services.Commands;
using Services.Interfaces;
using Services.Login;
using Services.Queries;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
ConfiguredServices(builder.Services);

builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

void ConfiguredServices(IServiceCollection services)
{
    services.AddDistributedMemoryCache();
    services.AddHttpContextAccessor();
    services.AddSession(option =>
    {
        option.IdleTimeout = TimeSpan.FromMinutes(30);
        option.Cookie.HttpOnly = true;
    });
    services.AddTransient<ILoginRepositoryQuery, GetUserPassword>();
    services.AddTransient<ILoginServiceCommands, LoginServiceCommands>();
    services.AddTransient<ISearchProductService, SearchProductService>();
    services.AddTransient<IRepositoryQueries, RepositoryQuery>();
    services.AddTransient<IServiceQueries, ServiceQueries>();
    services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    services.AddTransient<IRepositoryCommands, ProductCommandsRepository>();
    services.AddTransient<IServiceCommands, ProductCommandsServices>();
}
