# Étape 1 : Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copie du fichier projet et restauration des dépendances
COPY *.csproj ./
RUN dotnet restore

# Copie des autres fichiers et compilation
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Étape 2 : Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copie des fichiers publiés depuis l'étape de build
COPY --from=build /app/publish .

# Exposition du port (modifie selon ton app)
EXPOSE 80

# Lancement de l'application
ENTRYPOINT ["dotnet", "BoardgameCollectionSystem.dll"]