using InaForum.Domain;
using InaForum.Domain.Repository;
using InaForum.Domain.Repository.IRepository;
using InaForum.Infrastructure.Data;
using InaForum.Infrastructure.Repository;
using InaForum.Infrastructure.Repository.IRepository;
using InaForum.Logic;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddControllers();
services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContextPool<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InaForum"))
);

services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader());
});

//services.AddTransient <IRequestHandler<GetWeatherForecastQuery GetWeatherForecastQueryHandler>>();

services.AddScoped<IWeatherForeccastRepository, WeatherForecastRepository>();
services.AddScoped<IUserRepository, UserRepository>();


//services.AddTransient<IMediator, Mediator>();
services.AddTransient<IRequestHandler<GetWeatherForecastQuery, IEnumerable<WeatherForecast>>, GetWeatherForecastQueryHandler>();


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.UseRouting();
app.UseCors();

app.Run();
