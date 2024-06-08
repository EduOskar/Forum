using InaForum.Domain.Models;
using InaForum.Domain.Repository;
using InaForum.Domain.Repository.IRepository;
using InaForum.Infrastructure.Data;
using InaForum.Logic.Commands.CreateCommands;
using InaForum.Logic.Commands.HandleCommands;
using InaForum.Logic.Queries.QueryHandlers;
using InaForum.Logic.Queries.Querys;
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

services.AddScoped<IUserRepository, UserRepository>();


//services.AddTransient<IMediator, Mediator>();
services.AddTransient<IRequestHandler<GetUserQuery, User>, GetUserQueryHandler>();
services.AddTransient<IRequestHandler<GetAllUsersQuery, ICollection<User>>, GetAllUsersQueryHandler>();
services.AddTransient<IRequestHandler<CreateUserCommand, User>, CreateUserCommandHandler >();
services.AddTransient<IRequestHandler<DeleteUserCommand, bool>, DeleteUserCommandHandler >();


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
