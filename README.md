# Backend Dev with .NET Submission

This repository contains a .NET Web API project.

## Project Location

- `BackendDevWithDotNet`

## How to Run

1. Open a terminal in the repository root.
2. Run:

```bash
cd BackendDevWithDotNet
dotnet run
```

3. Use an API client like Postman with header:

```http
X-Api-Key: class-demo-api-key
```

## CRUD Endpoints (Users)

Base path: `/api/users`

- `GET /api/users` - Get all users
- `GET /api/users/{id}` - Get user by id
- `POST /api/users` - Create a user
- `PUT /api/users/{id}` - Update a user
- `DELETE /api/users/{id}` - Delete a user

Example body for POST/PUT:

```json
{
	"firstName": "Grace",
	"lastName": "Hopper",
	"email": "grace@example.com",
	"age": 30
}
```

## Validation Included

Validation is implemented with Data Annotations on request models:

- Required fields (`firstName`, `lastName`, `email`)
- Name length constraints
- Valid email format
- Age range: 18-120

Invalid requests automatically return `400 Bad Request` because of `[ApiController]`.

## Middleware Included

Custom middleware implemented:

- `RequestLoggingMiddleware` logs request method/path and response status code
- `ApiKeyAuthMiddleware` protects `/api/users` endpoints and checks `X-Api-Key`

## Copilot Debugging Notes

Copilot helped debug and complete the project by:

1. Verifying that .NET SDK and project setup were correct.
2. Replacing template weather endpoint with full users CRUD endpoints.
3. Fixing startup wiring in `Program.cs` so controllers, DI services, and middleware execute correctly.
4. Validating build success using `dotnet build`.

