# ✈️ Airline Booking System

A microservices-based airline booking backend built with .NET — designed to practice distributed systems patterns, async messaging, and clean service boundaries.

![alt text](airline_booking_flow_diagram.png)

## What is this?

This project simulates a real-world airline booking flow split across four independent services that communicate entirely through events — no direct HTTP calls between services. Once a booking is created, everything else (payment, notification, confirmation) happens automatically through the message bus.

## Services

| Service | Responsibility |
|---|---|
| **Booking** | Creates bookings and kicks off the whole flow |
| **Payment** | Processes payment after a booking is confirmed |
| **Notification** | Sends a notification after payment succeeds |
| **BuildingBlocks** | Shared contracts, events, and constants across services |

## Tech Stack

- **ASP.NET Core** — service hosts
- **MassTransit** — message bus abstraction
- **RabbitMQ** — message broker
- **MediatR** — in-process CQRS (commands/handlers per service)
- **Dapper + SQL Server** — data access
- **Docker** — runs RabbitMQ locally

## How the Flow Works

```
[Client] → Booking Service
              ↓ publishes FlightBookedEvent
         Payment Service
              ↓ publishes PaymentProcessedEvent
         Notification Service
              ↓ publishes NotificationEvent
         Booking Service (logs confirmation)
```

Each service only knows about the events it cares about — nothing more. The Booking service starts the chain and also closes it by consuming the final notification event.

### Event Queue Names

```
flight-booked-queue
payment-processed-queue
notification-sent-queue
```

## Project Structure

```
AirlineBookingSystem/
├── Bookings/
│   └── Application/
│       ├── Commands/
│       └── Consumers/          ← NotificationEventConsumer
├── Payments/
│   └── Application/
│       ├── Commands/
│       ├── Handlers/           ← ProcessPaymentHandler
│       └── Consumers/          ← FlightBookedConsumer
├── Notifications/
│   └── Application/
│       ├── Commands/
│       ├── Services/           ← NotificationService
│       └── Consumers/          ← PaymentProcessedConsumer
└── BuildingBlocks/
    └── Common/
        ├── EventBusConstant.cs
        └── Contracts/EventBus/Messages/
```


## What I Practiced Here

- Splitting a domain into bounded service contexts with no shared databases
- Event-driven choreography — services react to events instead of being called directly
- Using MassTransit to abstract away RabbitMQ plumbing
- Keeping each service's internal logic clean with MediatR commands and handlers
- Chaining async operations without coupling services to each other