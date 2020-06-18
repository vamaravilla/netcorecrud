# Job Board CRUD

CRUD for the Job entity using ASP.NET Core

## Prerequisites 🔧

* .NET Core 3.1
* Visual Studio 2019 / Visual Studio Code
* Git

## Installation 🔨

### 1. DataBase Migration

The solution has a Data Access Layer using Entity Framework (EF), you can test the operations with Database **In Memory**, using **SQL Server** or any supported by EF.
The proyect has a Data Base Migration and you can run the command **update-database -Context JobBoardMigrationContext** with your own Connection String.
```
PM> update-database -Context JobBoardMigrationContext
Build started...
Build succeeded.
Applying migration '20200616204012_Migration1.0'.
Done.
PM> 
```
### 2. Deploy Web App

There two options that I recommend: run the project locally (localhost using docker or IIS express) or deploy in Azure. You can find the project in the path **JobBoard\JobBoard.Mvc** or **JobBoard\JobBoard.BlazorApp**.
If you decide to use another database, don't forget to change the connection string in *appsettings.json* or *appsettings.Development.json*

```javascript
"ConnectionStrings": {
    "JobBoardConnectionString": "Server=....."
 }
```

## Usage ⚙️

You can visualize the MVC App in the follow URL:
* [https://vmjobboardmvc.azurewebsites.net](https://vmjobboardmvc.azurewebsites.net)

Also you can check a Blazor App (Alternative UI solution):
* [https://vmjobboardblazor.azurewebsites.net](https://vmjobboardblazor.azurewebsites.net)

## Built With

* [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1) - The Web framework used
* [Entity Framework Core 3.1](https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=netcore-cli) - ORM
* [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) - Used to build a interactive web UI
* [Azure SQL Database](https://azure.microsoft.com/es-es/services/sql-database/) - Cloud storage
* [Swagger UI](https://swagger.io/tools/swagger-ui/) - Used to the API visual documentation

## Author ✒️

* **Victor Maravilla** - [Likedin](https://www.linkedin.com/in/vamaravilla/)
