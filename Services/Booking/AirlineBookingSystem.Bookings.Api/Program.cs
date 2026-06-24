using System.Data;
using AirlineBookingSystem.Bookings.Api.Middleware;
using AirlineBookingSystem.Bookings.Core.Repositories;
using AirlineBookingSystems.Bookings.Infrastructure;
using Microsoft.Data.SqlClient;
using AirlineBookingSystem.Bookings.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Add Application Services
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

// Add Sql Connection
builder.Services.AddScoped<IDbConnection>(sp=>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))
 );

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(AssemblyMarker).Assembly);
});


var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();