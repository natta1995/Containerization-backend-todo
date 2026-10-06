# Steg 1: Förbered och bygg applikationen
# FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish


# Steg 2: Skapa den slutliga imagen
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

USER app

ENTRYPOINT ["dotnet", "backend-todo.dll"]