## Como Rodar o Projeto ##

  1. Acesse o diretorio four-six-api
  2. Suba o docker-compose.yml através do comando docker-compose up
  3. Após a aplicação subir acesse http://localhost:5293/swagger/index.html
  4. Para mais informações sobre o projeto acesse https://www.notion.so/22682d7ca9024037a102fe9ca4788932?v=531ac3130b5d4dd0aac0d0852b120de1&pvs=4

**Observações**

<p> Ao executar o docker-compose 2 container sobem no Docker, um banco SQLServer e uma API .NET
Existe um Healthcheck no SQL Server para garantir que a API só suba depois que o banco estiver no ar, porém
caso ocorra algo que a API suba antes do esperado, basta dar um, "start" na API </p>

## Comandos Para Auxilio ##

  ## Criar a Rede ##
  docker network create --driver bridge foursix-bridge
  
  ## Build Dockerfile Gerar Imagem ##
  C:\Projeto Estudo\Pos\fiap-fast-food\four-six-api> docker build -t damffranco/four-six-api:1.0.0 -f Dockerfile .
  
  ## Push Docker Hub ##
   docker push damffranco/four-six-api:1.0.0
  
   ## Gerar Latest ##
   docker tag damffranco/four-six-api:1.0.0 damffranco/four-six-api:latest
  
  ## Subir o Banco SQL Server (Rede) ##
  docker run -e "ACCEPT_EULA=Y" -e 'MSSQL_SA_PASSWORD=SenhaDoBanco(123)' -p 1433:1433 --name fourSixSql --network foursix-bridge -d mcr.microsoft.com/mssql/server:2022-latest
  
  ## Rodar a API da imagem do Dockerfile ##
  docker run -p 5293:80 --name=fourSixApi --network foursix-bridge -d d8fb04ea978d
