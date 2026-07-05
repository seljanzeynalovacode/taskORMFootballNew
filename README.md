# FootbolLigasORM

A .NET application built with Entity Framework Core, following a 3-layer (Layered/N-Tier) architecture, for managing football leagues, teams, players, and matches.

## Project Structure

```
FootbolLigasORM/
│
├── FootbolLigasORM.BLL   → Business Logic Layer
├── FootbolLigasORM.DAL   → Data Access Layer
├── FootbolLigasORM.UI    → Presentation Layer (API)
└── FootbolLigasORM.sln   → Solution file
```

### 🔹 FootbolLigasORM.DAL (Data Access Layer)
Handles direct communication with the database.
- **Entities** – Models such as League, Team, Player, Match, etc.
- **DbContext** – EF Core context configuration
- **Repository** – Generic/Specific repository pattern (CRUD operations)
- **Migrations** – Database schema changes

### 🔹 FootbolLigasORM.BLL (Business Logic Layer)
Contains business rules and service logic.
- **DTOs** – Data Transfer Objects (bridge between API and entities)
- **Services** – Business logic (validation, calculations, rules)
- **Mapping** – Entity ↔ DTO conversions (e.g. AutoMapper)
- **Interfaces** – Service contracts

### 🔹 FootbolLigasORM.UI (Presentation Layer)
Handles communication with the client/user.
- **Controllers** – API endpoints (Leagues, Teams, Players, etc.)
- **Program.cs / Startup** – DI configuration, middleware
- **Swagger** – API documentation and testing interface

## Architecture Principle

```
UI (Controllers)
   ↓ uses
BLL (Services, DTOs)
   ↓ uses
DAL (Repositories, Entities, DbContext)
   ↓ connects to
Database (SQL Server)
```

Each layer only communicates with the layer directly below it (UI does not access DAL directly).

## Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/seljanzeynalovacode/taskORMFootballNew/
   ```
2. Configure the connection string in `appsettings.json` to match your SQL Server:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=.;Database=FootbolLigasORM;Trusted_Connection=True;TrustServerCertificate=True"
   }
   ```
3. Apply migrations:
   ```bash
   dotnet ef database update --project FootbolLigasORM.DAL --startup-project FootbolLigasORM.UI
   ```
4. Run the project:
   ```bash
   dotnet run --project FootbolLigasORM.UI
   ```


## Technologies

- .NET (ASP.NET Core Web API)
- Entity Framework Core
- SQL Server
- AutoMapper (if used)
- Swagger / Swashbuckle

## Note

This README is based on a generic 3-layer architecture structure. If you'd like the content tailored to your actual Entity, DTO, and Service names, feel free to share your existing code (e.g. the DAL/Entities and BLL/DTOs folders) so I can update the README to match your real structure.
