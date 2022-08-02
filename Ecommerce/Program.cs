using Microsoft.EntityFrameworkCore;
using Repository.Commands;
using Repository.DataContext;
using Repository.Interfaces;
using Services.Commands;
using Services.Interfaces;

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
    services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    services.AddTransient<ICommandsRepository, ProductCommandsRepository>();
    services.AddTransient<ICommandsServices, ProductCommandsServices>();
}