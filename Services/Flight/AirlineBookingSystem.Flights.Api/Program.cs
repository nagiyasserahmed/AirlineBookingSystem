using System.Data;
using AirelineBookingSystem.Flights.Core.Repositories;
using AirelineBookingSystem.Flights.Infrastructure;
using AirlineBookingSystem.Flights.Api.Middleware;
using AirlineBookingSystem.Flights.Application;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// App Services
builder.Services.AddScoped<IFlightRepository, FlightRepository>();

// Db Connection
builder.Services.AddScoped<IDbConnection>(sp=>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(AssemblyMarker).Assembly);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();

