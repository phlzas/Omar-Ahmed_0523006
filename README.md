# Omar Ahmed — University Coursework

University coursework repository (student ID **0523006**) containing an ASP.NET Core Web API assignment: a **football club management system** built with Entity Framework Core.

## Overview

This project is a single ASP.NET Core 8 Web API solution that models a football club and its related data. It demonstrates the core concepts of a database-driven .NET web application:

- **Entity Framework Core** — Code First modelling with entity relationships (one-to-one, one-to-many, many-to-many)
- **EF Core migrations** — schema creation and evolution (`init`, `init1`)
- **Seed data** — sample teams, coaches, players, and competitions defined in `OnModelCreating`
- **Repository pattern** — a generic repository (`GenericRepo<T>`) plus entity-specific repositories
- **Dependency injection** — repositories registered in `Program.cs`
- **LINQ queries** — projections, grouping, and eager loading (`Include` / `ThenInclude`)
- **REST controllers** — CRUD-style endpoints documented with Swagger

### Domain model

| Entity          | Description                                                        |
|-----------------|--------------------------------------------------------------------|
| `Team`          | Football team — `Name` (unique), `City`, and a required `Coach`    |
| `Coach`         | Coach — `Name`, `Speclatation` (specialization), `ExpYears`        |
| `player`        | Player — `FullName`, `Postion` (position), `Age`, belongs to a team |
| `Compttion`     | Competition — `Titel` (title), `Locatioon` (location), `DateComp`  |
| `TeamCompttion` | Join entity linking teams and competitions (composite key)         |

## What's Inside

```
Omar Ahmed_0523006/
├── Controllers/            # Team, Player, Coach, Competition endpoints
├── Data/
│   ├── AppDbContext.cs     # DbContext, relationships, seed data
│   └── Models/             # Team, Coach, player, Compttion, TeamCompttion
├── Dtos/                   # TeamDto (request payload for team creation)
├── Migrations/             # EF Core migrations (init, init1)
├── RepostryPattern/        # GenericRepo + per-entity repositories
├── Program.cs              # Service registration and middleware pipeline
└── appsettings.json        # SQL Server LocalDB connection ("Club" database)
```

### Endpoints (as declared)

| Controller           | Method | Route                    | Purpose                                  |
|----------------------|--------|--------------------------|------------------------------------------|
| `CoahesController`   | GET    | `GetAllCoaches`          | List coaches grouped by specialization   |
| `CoahesController`   | GET    | `GetCoache{id}`          | Teams for a specific coach               |
| `PLayerController`   | PUT    | `UpdateSeplaization`     | Update a player's position               |
| `PLayerController`   | GET    | `GetAll`                 | List players grouped by team             |
| `TeamController`     | POST   | `CreateTeamWihtCoach`    | Create a team linked to a coach          |
| `TeamController`     | GET    | `GetAllWihtNoComptions`  | List teams with their player counts      |
| `ComptionController` | DELETE | `DeleteIfExsite`         | Delete a competition if it exists        |
| `ComptionController` | GET    | `GettWithData`           | Competition participation summary        |

## Tech Stack

- **.NET 8** — ASP.NET Core Web API (`net8.0`)
- **Entity Framework Core 8.0.21** — Code First, migrations, seed data
- **SQL Server** — LocalDB (`(localdb)\MSSQLLocalDB`, database `Club`)
- **Swashbuckle / Swagger** — API documentation in development
- **Repository pattern** with generic repository and custom repositories

## How to Run

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server **LocalDB**

### Steps

```bash
# 1. Restore dependencies
dotnet restore

# 2. Apply migrations (creates the "Club" database and seed data)
dotnet ef database update --project "Omar Ahmed_0523006"

# 3. Run the API
dotnet run --project "Omar Ahmed_0523006"
```

Swagger UI is available at:

- `http://localhost:5216/swagger`

## Notes

- This is **student coursework** (submitted under student ID 0523006), not a production system. It is kept short and its code reflects a learning exercise.
- **Status:** the project is a work in progress and currently contains a syntax error in `ComptionController.GettWithData` (an incomplete member access), so it does not compile as-is. Several controller actions also have logic issues, and the controllers lack `[Route]`/`[ApiController]` attributes — with only `MapControllers()` configured and no conventional routing, the declared endpoints are not reachable via HTTP yet.
- Entity/property names contain spelling inconsistencies (`Speclatation`, `Postion`, `Compttion`, `Locatioon`, `RepostryPattern`) that are preserved as-is from the original coursework.
