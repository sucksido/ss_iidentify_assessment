**Prerequisites**
Before you begin, ensure you have the following installed on your machine:
* .NET 7 SDK
* SQL Server
* Docker (if you prefer running SQL Server in a container)
* Postman

`git clone https://github.com/yourusername/ssforumapi.git`
`cd ssforumapi`

Pull the SQL Server Docker image:
`docker pull mcr.microsoft.com/mssql/server`

Run the SQL Server container:
`docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=YourPassword123!' -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server`

Create the database:
`docker exec -it sqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 'YourPassword123!' -Q 'CREATE DATABASE ForumDB'`


Update the connection string in the appsettings.json file to match your SQL Server setup:

`{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ForumDB;User Id=sa;Password=YourPassword123!;MultipleActiveResultSets=true"
  },
  "Jwt": {
    "Key": "YourSecretKeyHere",
    "Issuer": "YourIssuer",
    "Audience": "YourAudience"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}`


`dotnet ef database update`

`dotnet run`
