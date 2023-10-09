#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["four-six-api/src/FourSix.WebApi/FourSix.WebApi.csproj", "four-six-api/src/FourSix.WebApi/"]
RUN dotnet restore "four-six-api/src/FourSix.WebApi/FourSix.WebApi.csproj"
COPY . .
WORKDIR "/src/four-six-api/src/FourSix.WebApi"
RUN dotnet build "FourSix.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FourSix.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FourSix.WebApi.dll"]