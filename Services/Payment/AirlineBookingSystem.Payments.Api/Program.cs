using System.Data;
using AirlineBookingSystem.Payments.Application;
using AirlineBookingSystem.Payments.Core.Repositories;
using AirlineBookingSystem.Payments.Infrastructure;
using Microsoft.Data.SqlClient;
using MassTransit;
using AirlineBookingSystem.BuildingBlocks.Common;
using AirlineBookingSystem.Payments.Application.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Application Services
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

// MassTransit
builder.Services.AddMassTransit(cfg =>
{
    cfg.AddConsumer<FlightBookedConsumer>();

    cfg.UsingRabbitMq((ct, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        cfg.ReceiveEndpoint(EventBusConstant.FlightBookedQueue, c =>
        {
            c.ConfigureConsumer<FlightBookedConsumer>(ct);
        });
    });
});

// Db Connection
builder.Services.AddScoped<IDbConnection>(sp=>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddMediatR(cfg =>
{
   cfg.RegisterServicesFromAssemblies(typeof(AssemblyMarker).Assembly); 
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
