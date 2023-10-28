Comando do Banco
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=P@$$w0rd" -p 1433:1433 --name sql1 --hostname sql1 -d mcr.microsoft.com/mssql/server:2022-latest


Migrations
Add-Migration  InitialMigrations
update-database

Migration via CMD
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialMigrations
dotnet ef database update