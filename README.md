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

### API endpoint information
## Get Games Details With Pagination
Retrieves a collection of games based on pagination parameters.

### HTTP Method & URL
`GET /api/games/page`

### Query Parameters
- `pageNumber` (optional): The number of the current page (default is 1).
- `pageSize` (optional): The total number of records per page (default is 10).

### Responses
- `200 OK`: Successfully retrieved the games. The response includes a list of games and pagination details in the `X-Pagination` response header.
- `400 Bad Request`: Invalid request, typically due to a problem with input values. Ensure `pageNumber` and `pageSize` are greater than 0.

### Headers
- `X-Pagination`: Contains JSON serialized pagination metadata including total items, total pages, current page, item count on current page, etc.
### Sample Request
- https://localhost:7003/api/games/page?pageNumber=1&pageSize=10

## Get Game Detail With Game id.
Retrieves a game details based on game id.

### HTTP Method & URL
`GET /api/games/{id}`

### Query Parameters
- `id` : The number of the game id.

### Responses
- `200 OK`: Successfully retrieved the game.
- `400 Bad Request`: Invalid request.
- `404 Not Found`: Id doest not exists

### Sample Request
- https://localhost:7003/api/games/1

## Get Games Detail 
Retrieves a collection of games details.

### HTTP Method & URL
`GET /api/games`

### Responses
- `200 OK`: Successfully retrieved the games or empty data.

### Sample Request
- https://localhost:7003/api/games

## Add Games Details to Database
Add Data to Game Hub DB

### HTTP Method & URL
`POST /api/games`

### Responses
- `200 OK`: Successfully Added the games.
- `400 Bad Request`: Invalid request data

### Sample Request
- https://localhost:7003/api/games
- Request Body: {
  "title": "string",
  "genre": "string",
  "description": "string",
  "price": 0,
  "releaseDate": "2024-10-21T04:50:11.445Z",
  "stockQuantity": 0
}


## Update Games Details to Database
Update Data to Game Hub DB

### HTTP Method & URL
`PUT /api/games/1`

### Responses
- `204 No Content`: Successfully Updated the games.
- `400 Bad Request`: Invalid request data

### Sample Request
- https://localhost:7003/api/games/1
- Request Body: {
  "title": "string",
  "genre": "string",
  "description": "string",
  "price": 0,
  "releaseDate": "2024-10-21T04:50:11.445Z",
  "stockQuantity": 0

}
## Delete Games Details to Database
Delete Data to Game Hub DB

### HTTP Method & URL
`DELETE /api/games/1`

### Responses
- `204 No Content`: Successfully Updated the games.
- `404 Not Found`: Id does not exists in DB

### Sample Request
- https://localhost:7003/api/games/1

