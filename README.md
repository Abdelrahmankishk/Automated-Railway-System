# 🚆 Automated Railway System

A **C# console-based Automated Railway System** designed to simulate train-ticket reservation and railway operations while applying core **Object-Oriented Programming (OOP)** principles in a clean **single-project monolithic architecture**.

The system manages clients, golden-client benefits, train tickets, trains, engines, reservations, cancellations, and ticket pricing while providing a structured interactive console interface.

---

## 📌 Overview

The Automated Railway System allows railway staff/users to manage the main operations of a railway station from a console menu.

The application supports:

- Registering and managing clients.
- Determining whether a client qualifies as a **Golden Client**.
- Managing trains, engines, train services, and tickets.
- Reserving and cancelling train tickets.
- Calculating ticket prices according to age, pensioner, and golden-client rules.
- Tracking client travel count and total travelled distance.
- Monitoring engine oil-change and maintenance requirements.
- Displaying clients, tickets, trains, available tickets, and purchase history.
- Handling invalid operations through exception-based validation.

---

## ✨ Main Features

### 👤 Client Management

Each client is identified by:

- Client ID
- Name
- Age
- Address
- Pensioner status
- Date of birth
- Preferred station
- Number of travels
- Total travelled distance
- Purchased tickets

The system provides multiple ways to register clients and prevents invalid operations through validation and exceptions.

### ⭐ Golden Clients

A client becomes a **Golden Client** when either of the following conditions is met:

- Number of travels exceeds **50**.
- Total travelled distance exceeds **10,000 km**.

Golden clients receive special ticket benefits based on the travel date and destination station.

### 💰 Ticket Discount System

The final ticket price is calculated dynamically using the following rules:

| Client / Travel Condition | Discount / Benefit |
|---|---:|
| Golden client travelling on their birthday | **100% — Free ticket** |
| Golden client travelling to preferred station | **50%** |
| Golden client otherwise | **20%** |
| Client older than 70 | **50%** |
| Pensioner | **20%** |

The implementation applies the business rules sequentially inside `Ticket.CalculateFinalPrice()`.

Users can:

1. Select a client.
2. View all available tickets.
3. Reserve a ticket.
4. Calculate the final purchase price.
5. Record the reservation date.
6. Add the purchased ticket to the client's history.

Reserved tickets are no longer displayed as available.

### ❌ Ticket Cancellation

A reserved ticket can be cancelled.

After cancellation, the system creates a **new available ticket with a new ticket ID** using the cancelled ticket's train, route, distance, travel date, and original price.

This keeps the ticket history intact while returning the travel offer to the pool of available tickets.

### 🚆 Train Management

Each train contains:

- Train number
- Train type
- Maximum speed
- Available services
- One engine

Supported train services include:

- Wi-Fi
- Meal
- Drink
- Screens

### 🔧 Engine Monitoring

Each train contains an engine identified by:

- Engine ID
- Engine type
- Distance travelled

Maintenance rules:

- At **20,000 km**, an oil change is required.
- At **100,000 km**, maintenance is required.

The system exposes engine status through the console display.

---

## 🖥️ Application Menu

When the application starts, the user can choose from the following operations:

```text
════════════════════════════════════════
       RAILWAY SYSTEM - MAIN MENU
════════════════════════════════════════
  1. Show All Clients
  2. Show All Tickets
  3. Show All Trains
  4. Show Available Tickets
  5. Client Purchase History
  6. Reserve Ticket
  7. Cancel Ticket
  8. Register New Client
----------------------------------------
  0. Exit
========================================
Enter your choice:
```

### Available Operations

| Option | Operation |
|---:|---|
| 1 | Display all registered clients |
| 2 | Display all registered tickets |
| 3 | Display all registered trains |
| 4 | Display available tickets only |
| 5 | Display a client's purchased-ticket history |
| 6 | Reserve a ticket |
| 7 | Cancel a reservation|
| 8 | Register a new client |
| 0 | Exit the application |

---

## 🧮 Ticket Pricing Implementation

The project centralizes ticket price calculation inside the `Ticket` entity.

The calculation checks golden-client rules first and then evaluates the age and pensioner conditions.

```csharp
public decimal CalculateFinalPrice()
{
    decimal finalPrice = price;

    if (client!.IsGolden)
    {
        if (client.DateOfBirth.Month == TravelDate.Month &&
            client.DateOfBirth.Day == TravelDate.Day)
        {
            return 0;
        }

        if (client.PreferedStation == DestinationStation)
            finalPrice *= 0.5m;
        else
            finalPrice *= 0.8m;
    }

    if (client.Age > 70)
        finalPrice *= 0.5m;

    if (client.Pensoiner)
        finalPrice *= 0.8m;

    return finalPrice;
}
```

## 🔧 Engine Maintenance Logic

Engine status is determined from its travelled distance:

```csharp
public bool ChecKOil() =>
    DistanceTraveled >= OilChangeInterval &&
    DistanceTraveled <= MaintenanceInterval;

public bool CheckMaintenance() =>
    DistanceTraveled >= MaintenanceInterval;
```

The display layer then converts these checks into a readable status such as:

```text
Distance Traveled: 30000 km (Oil change required!, No Maintenance required)
```

or:

```text
Distance Traveled: 150000 km (Oil is GOOD, Maintenance required)
```

---

## 🏗️ Architecture

All functionality exists in one .NET project and is organized internally into folders according to responsibility.

```text
Automated Railway System
│
├── Contracts/
│   ├── IDisplayable.cs
│   └── IReservable.cs
│
├── Extensions/
│   ├── IntegerExtensions.cs
│   └── StringExtensions.cs
│
├── Helpers/
│   ├── ConsoleHelper.cs
│   └── DataSeeder.cs
│
├── Images/
│
├── Models/
│   ├── Enums/
│   │   ├── EngineTypes.cs
│   │   ├── Stations.cs
│   │   ├── TicketStatus.cs
│   │   ├── TrainServices.cs
│   │   └── TrainTypes.cs
│   ├── Client.cs
│   ├── Engine.cs
│   ├── RailwayStation.cs
│   ├── Ticket.cs
│   └── Train.cs
│
├── Services/
│   ├── DisplayService.cs
│   └── RailwayService.cs
│
└── Program.cs
```

### Architectural Responsibilities

**Models** contain the core railway domain entities and their related behavior.

**Services** coordinate application workflows such as registration, reservation, cancellation, and presentation operations.

**Contracts** define reusable interfaces such as displayable and reservable behavior.

**Extensions** provide reusable helper functionality without modifying the original model classes.

**Helpers** contain console utilities and initial/sample data seeding.

---

## 🧠 OOP Concepts Applied

The project was designed as an OOP-focused implementation and applies several important concepts:

### Encapsulation

Private fields and controlled properties/methods protect internal state such as:

- Ticket price and status.
- Client purchased-ticket collections.
- Railway Station collections.
- Engine distance tracking.

### Abstraction

Interfaces such as `IDisplayable` and `IReservable` define common behavior contracts that can be implemented by different classes.

### Composition

A `Train` owns an `Engine`, representing the strong whole-part relationship required by the business rules.

```text
Train ◆──── Engine
```

### Association

Tickets are associated with the client who purchases them and the train used for the journey.

### Enumerations

Enums are used to represent fixed categories such as:

- `TrainTypes`
- `TrainServices`
- `EngineTypes`
- `TicketStatus`
- `Stations`

### Static Members

Counters are used to generate unique identifiers for clients, tickets, trains, and engines.

### Interfaces

The project separates contracts from implementation through interfaces such as:

```text
IDisplayable
IReservable
```

### Extension Methods

Reusable behavior is implemented through extension classes, including integer and string helper extensions used by the application.

### Exception Handling

Invalid input and invalid business operations are handled using exceptions to keep the system in a valid state and provide clear feedback to the user.

---

## 📊 UML Class Diagram

The implemented system was designed from a UML class diagram (in the Images folder) that represents the main entities, relationships, attributes, and operations of the railway domain.

---

## 📋 Example Workflows

### Reserve a Ticket

```text
Enter your choice: 6

Enter Client ID : user-101

... Available Tickets ...

Enter Ticket ID u want to reserve : ticket-002
TICKET-002 has been successfully reserved by Client: Abdelrahman Keshk
Reservation Date: 04/10/2026 , (20:51:05)
```

### Cancel a Ticket

```text
Enter your choice: 7

Enter Ticket ID u want to cancel : ticket-002
Reservation for TICKET-002 has been successfully Canceled
```

The cancelled reservation is then represented by a newly created available ticket with a new ID.

### Register a Client

```text
Enter your choice: 8

Enter your name : Youssef keshk
Enter your age : 28
Enter your Year of Birth (YYYY) : 1998
Enter your Month of Birth (MM) : 01
Enter your Day of Birth (DD) : 02
Enter your Home address : Amesterdam, Netherlands

Enter your preferred station : 1

Client :Youssef keshk with ID USER-106 has been successfully added to the system
```

---

## 📦 Seeded Sample Data

The application includes seeded data to demonstrate the business rules without requiring manual setup.

Sample data covers:

- Regular clients.
- Golden clients qualifying through travel count.
- Golden clients qualifying through total travelled distance.
- Pensioner clients.
- Clients older than 70.
- Multiple train types and engine types.
- Different travel dates, stations, prices, and distances.
- Available and reserved ticket scenarios.

---

## 🛠️ Technologies Used

- **C#**
- **.NET**
- **Console Application**
- **Object-Oriented Programming**
- **UML Class Modeling**
- **Generics / Collections**
- **Interfaces**
- **Enums**
- **Extension Methods**
- **Exception Handling**

---

## 🎯 Project Goals

This project was built to practice designing a complete object-oriented system from business requirements and translating those requirements into:

- Domain models.
- Object relationships.
- Business rules.
- Service-level workflows.
- Validation and exception handling.
- Reusable interfaces and extension methods.
- A maintainable monolithic project structure.

---

## 🔮 Future Enhancements

The current system implements the required railway operations and business rules. The following enhancements are planned to make the application more informative and realistic:

### 💸 Display the Applied Discount

The console currently displays the original ticket price and the final purchase price. A future enhancement would explicitly show the **discount applied to each ticket**, including the discount percentage and the amount saved.

For example:

```text
Initial Price: 300 EGP
Discount: 20% (60 EGP)
Final Price: 240 EGP
```

For a free birthday ticket, the console could display:

```text
Initial Price: 500 EGP
Discount: 100% (500 EGP)
Final Price: 0 EGP
```

This would make the pricing rules clearer to users and improve the transparency of the reservation process.

### 📈 Update Travel Statistics After Trip Completion

Currently, a client's **number of travels** and **total travelled distance** are used to determine Golden Client eligibility. A future enhancement would update these values automatically **when the trip is completed**, rather than at reservation time.

After a completed journey, the system could update:

```text
Travel Count: +1
Total Distance: +300 km
```

This would make Golden Client qualification more realistic because travel statistics would represent **completed journeys** instead of merely reserved tickets. It would also allow the system to support future features such as trip completion status and historical travel tracking.

### 🚀 Additional Possible Improvements

Other future enhancements could include persistent database storage, a graphical or web-based interface, and stronger separation of application concerns as the system grows.

---

## 👨‍💻 Author

**Abdelrahman Keshk**

GitHub: https://github.com/Abdelrahmankishk
