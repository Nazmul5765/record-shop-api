# Record Shop API

The backend API for my full-stack Record Shop application.

The application provides record inventory management, allowing users to browse, search, add, update and delete albums through the Blazor frontend.

The API was built with ASP.NET Core using a layered Controller, Service and Repository architecture. Entity Framework Core is used for database access, with PostgreSQL used in production and SQL Server supported for local development.

## Live Application

**Frontend:** https://recordshop.nazmulhussain.co.uk

The production API is hosted on Railway and connects to a PostgreSQL database hosted on Neon.

---

## Features

### Album Management

- Get all albums
- Get an album by ID
- Add new albums
- Update existing album details
- Delete albums

### Searching and Filtering

Albums can be searched or filtered by:

- Title
- Artist
- Genre
- Release year

### Health Checks

The API includes health checks for:

- API availability
- Database connectivity

These are exposed through the `/health` endpoint and are also used by Railway to verify that the deployed service is running correctly.

### Error Handling

The API handles invalid requests, missing data and resources that cannot be found, returning appropriate HTTP responses to the frontend.

---

## Technologies Used

- C#
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- SQL Server
- Neon
- Docker
- Railway
- Swagger / OpenAPI
- NUnit
- Moq
- Shouldly
- Git and GitHub

---

## Architecture

The application follows a layered architecture:

```text
Client
  ↓
Controller
  ↓
Service
  ↓
Repository
  ↓
Entity Framework Core
  ↓
Database
```

### Controllers

Handle incoming HTTP requests and return API responses.

### Services

Contain application and business logic.

### Repositories

Handle database operations and isolate data access from the rest of the application.

### Entity Framework Core

Provides communication between the repository layer and the configured database.

---

## API Endpoints

### Albums

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/albums` | Get all albums |
| GET | `/api/albums/{id}` | Get an album by ID |
| POST | `/api/albums` | Add a new album |
| PUT | `/api/albums/{id}` | Update an album |
| DELETE | `/api/albums/{id}` | Delete an album |

### Filtering

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/albums/title/{title}` | Search by album title |
| GET | `/api/albums/artist/{artistName}` | Get albums by artist |
| GET | `/api/albums/genre/{genre}` | Get albums by genre |
| GET | `/api/albums/releaseYear/{releaseYear}` | Get albums by release year |

### Health Check

| Method | Endpoint | Description |
|---|---|---|
| GET | `/health` | Check API and database health |

---

## Database Configuration

The application supports different database configurations depending on the environment.

### Production

The deployed API uses:

```text
Railway
   ↓
ASP.NET Core API
   ↓
Entity Framework Core
   ↓
PostgreSQL
   ↓
Neon
```

The PostgreSQL connection string is supplied through environment variables rather than being stored in the repository.

### Local Development

SQL Server can be used for local development.

Connection strings are stored using .NET User Secrets so sensitive database credentials are not committed to GitHub.

The application can also use an Entity Framework Core InMemory database when configured to do so.

---

## Running the Project Locally

### 1. Clone the Repository

```bash
git clone https://github.com/Nazmul5765/Record-Shop.git
```

### 2. Navigate to the Repository

```bash
cd Record-Shop
```

### 3. Configure the Database

Provide the required database connection string using .NET User Secrets or your local configuration.

For SQL Server, the application uses:

```text
ConnectionStrings:DefaultConnection
```

### 4. Apply Database Migrations

Using the Package Manager Console:

```powershell
Update-Database
```

Or using the .NET CLI:

```bash
dotnet ef database update
```

### 5. Run the API

```bash
dotnet run
```

---

## Docker

The API is containerised using Docker for deployment.

The Docker image:

1. Restores the project dependencies
2. Publishes the ASP.NET Core application
3. Runs the published application using the .NET 8 ASP.NET runtime
4. Binds to the port supplied by the hosting environment

Railway builds and deploys the application from the GitHub repository.

---

## Swagger

Swagger / OpenAPI is enabled for exploring and testing the API endpoints.

When running locally, Swagger can be accessed at:

```text
https://localhost:<port>/swagger
```

---

## Testing

The project contains automated tests across the application layers.

### Repository Tests

Test database access and repository behaviour using an Entity Framework Core InMemory database.

### Service Tests

Use Moq to isolate repository dependencies and test service behaviour.

### Controller Tests

Verify controller responses for successful requests, invalid requests and resources that cannot be found.

### Testing Tools

- NUnit
- Moq
- Shouldly
- Entity Framework Core InMemory

Run the test suite with:

```bash
dotnet test
```

---

## Frontend

The API is consumed by a separate Blazor frontend.

**Live application:**  
https://recordshop.nazmulhussain.co.uk

**Frontend repository:**  
https://github.com/Nazmul5765/record-shop-frontend

---

## Future Improvements

Possible future improvements include:

- Authentication and user accounts
- Pagination for larger record collections
- Additional sorting and filtering options
- More detailed health check reporting
- Expanded automated test coverage

---

## Author

**Nazmul Hussain**

Junior C#/.NET Developer

- Portfolio: https://nazmulhussain.co.uk
- GitHub: https://github.com/Nazmul5765
- LinkedIn: https://www.linkedin.com/in/nazmul-hussain/
