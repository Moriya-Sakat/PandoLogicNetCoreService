# PandoLogic NetCoreService

## Getting Started

### Requirements

-   .NET SDK 6.0
-	MySql Server


### Installation


* Clone [PandoLogicNetCoreService](https://github.com/Moriya-Sakat/PandoLogicNetCoreService).

* Clone [PandoLogicNetCoreServiceTests](https://github.com/Moriya-Sakat/PandoLogicNetCoreServiceTests).

* Move PandoLogicTests folder into PandoLogicNetCoreService folder.

* Restore NuGet packages.

* DB:
  * Config MySql local ConnectionString under ConnectionStrings -> MySql on `appsettings.Development.json` file.
  * Run `dotnet ef database update` for creating the DB.

* The project will run on `http://localhost:5000`.
	


