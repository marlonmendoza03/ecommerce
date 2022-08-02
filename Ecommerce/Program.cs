using Microsoft.EntityFrameworkCore;
using Repository.DataContext;
using Repository.Interfaces;
using Repository.Queries;
using Services.Interfaces;
using Services.Queries;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
ConfiguredServices(builder.Services);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfiguredServices(IServiceCollection services)
{
    services.AddTransient<IRepositoryQueries, RepositoryQuery>();
    services.AddTransient<IServiceQueries, ServiceQueries>();
    services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
}
