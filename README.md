# Payment Portal (Angular + ASP.NET Core Web API)

A full-stack CRUD application built to practise connecting an Angular
frontend to an ASP.NET Core Web API backed by SQL Server.

## Tech stack
- Frontend: Angular, TypeScript, RxJS
- Backend: ASP.NET Core Web API (C#), Entity Framework Core
- Database: SQL Server (LocalDB)

## Run locally
### Database and API
1. Open `api` and set the connection string in `appsettings.json`.
2. dotnet ef database update
3. dotnet run   (the API runs at http://localhost:5080)

### Angular app
1. cd web
2. npm install
3. ng serve   (open http://localhost:4200)

## Status
Work in progress: adding JWT authentication, a payments-themed
Transaction model and duplicate-submit protection.
