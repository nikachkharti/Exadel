# Exadel

This is ASP.NET Core web api for BookManagement using .NET 8 version SQL Server database and EF Core as ORM.
Project is separated into multiple layers:

  **Repository** - Responsible for database communication using EF core
  It uses generic repository pattern with entity framework core code first approach.
  Also context class uses things like data seeding and middleware for auto database creation.

  **Service** - Responsible for business logic complete uses services and DTO classes, also Automapper library for data mapping.
  This project uses UnitOfWork pattern for better dependency injection practice.

  **Models** - Responsible to store entity and worker classes.

  **API** - Main executable application with controllers. 
  Endpoints are secured with role based identity and jwt token.
