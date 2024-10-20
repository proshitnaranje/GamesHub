# GameHub

This project is an ASP.NET Core Web API designed to manage a collection of video games Information. It provides endpoints to perform CRUD (Create, Read, Update, Delete) operations on game data.

## Technologies
- ASP.NET Core 8.0.10
- Entity Framework Core 8.0.10
- SQLite

## Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.
- Clone the respository on your local machine
- Build the application to install all nuget packages.
- Execute migration command if local Sqllite db not created when run the project
- 1st Migration Command :   add-migration <nameForMigration>
- 2nd Command : update-database

### Prerequisites
What you need to install the software:
- [.NET 8.0.10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Any IDE that supports .NET (e.g., [Visual Studio](https://visualstudio.microsoft.com), [VS Code](https://code.visualstudio.com))

### Installing
A step by step series of examples that tell you how to get a development environment running:
1. Clone the repository:
   ```bash
   git clone https://github.com/proshitnaranje/game-api.git
