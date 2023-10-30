Comando do Banco
docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=P@$$w0rd123' -p 1433:1433 --name sql1 --hostname sql1 -d mcr.microsoft.com/mssql/server:2022-latest

Comando da aplica��o
docker run -d --name foursixwebapi -p 8000:80 foursixwebapi

Gerar imagem:
docker build -t foursixwebapi .

OU

Abrir o VS
Bot�o direito arquivo Dockerfile

Subir imagem:
docker login
docker tag foursixwebapi ivangomesneto/foursixwebapi:1.0.0
docker push ivangomesneto/foursixwebapi:1.0.0


Migrations
Add-Migration  InitialMigrations
update-database

Migration via CMD
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialMigrations
dotnet ef database update