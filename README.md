![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?logo=microsoftsqlserver&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-7952B3?logo=bootstrap&logoColor=white)

# Final Project Razor

A recipe management web application built with ASP.NET Core Razor Pages, developed as the capstone project for the **Assembly Junior Developer 2.0** bootcamp.

Users can browse, create, and rate recipes; manage ingredients, categories, and difficulty levels; comment and save favorites; and administrators can moderate submitted content.

## Features

- **Recipes** — create, browse, search, update, and moderate (approve/block) recipes
- **Ingredients & units** — manage ingredients and link them to recipes with quantities and units of measurement
- **Categories & difficulty levels** — organize recipes for easier discovery
- **Ratings & comments** — users can rate and comment on recipes
- **Favorites** — users can save recipes to a personal list
- **Accounts** — registration, login/logout, session-based authentication
- **Admin moderation** — block/unblock users and recipes
- **Search** — find recipes by keyword

## Tech Stack

**Backend**
- ASP.NET Core 8 (Razor Pages) / C#
- ADO.NET (`Microsoft.Data.SqlClient`) with a layered Repository / Service architecture
- SQL Server

**Frontend**
- Razor views (`.cshtml`)
- Bootstrap 5
- jQuery / jQuery Validation

## Project Structure

```
Final Project Razor.sln
├── Final Project Razor/   Web app — Razor Pages, Program.cs, wwwroot
├── Models/                Domain entities (Recipes, Users, Ingredients, ...)
├── Repository/            Data access layer (ADO.NET)
├── Services/               Business logic layer
└── Database/               SQL schema, seed data, ER diagram
```

## Database

The schema (tables, primary/foreign keys) plus sample seed data is in [`Database/Create Tables, PKs and FKs (Corrigido).sql`](Database/Create%20Tables%2C%20PKs%20and%20FKs%20%28Corrigido%29.sql).

![Entity Relationship Diagram](Database/Diagrama%20Projecto%20Final.png)

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (LocalDB, Express, or a full instance)

### Setup

1. Clone the repository
   ```bash
   git clone https://github.com/M4lk4vian/Final-Project-Razor.git
   cd Final-Project-Razor
   ```
2. Create the database by running [`Database/Create Tables, PKs and FKs (Corrigido).sql`](Database/Create%20Tables%2C%20PKs%20and%20FKs%20%28Corrigido%29.sql) against it — it creates the schema and seeds it with sample data in one go.
3. Create an `appsettings.json` inside `Final Project Razor/` (it's git-ignored, so it won't exist after cloning) with your own connection string:
   ```json
   {
     "ConnectionStrings": {
       "SqlServerAssembly": "Data Source=YOUR_SERVER;Initial Catalog=YOUR_DB;Trusted_Connection=True;Encrypt=False"
     }
   }
   ```
4. Run the app:
   ```bash
   cd "Final Project Razor"
   dotnet run
   ```
5. Open the URL shown in the terminal (e.g. `https://localhost:7279`).

## Live Demo

🔗 [final-project-razor-a6d2acf0egegche3.francecentral-01.azurewebsites.net](https://final-project-razor-a6d2acf0egegche3.francecentral-01.azurewebsites.net)

Hosted on Azure App Service (free tier) with an Azure SQL Database backend. The free tier spins down after periods of inactivity, so the first request after a while may take a few extra seconds while it wakes back up.

## About This Project

This was built as the capstone project for the **Assembly Junior Developer 2.0** bootcamp, covering full-stack development with C#, ASP.NET Core, and SQL Server — from database design to a working multi-page web application with authentication, CRUD operations, and role-based moderation.

## Author

**João Falcão Tavares**
- GitHub: [@M4lk4vian](https://github.com/M4lk4vian)
- LinkedIn: [linkedin.com/in/joao-falcao-tavares-659a61125](https://www.linkedin.com/in/joao-falcao-tavares-659a61125)
