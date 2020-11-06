#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["FactorioServerManager.WebUi/FactorioServerManager.WebUi.csproj", "FactorioServerManager.WebUi/"]
COPY ["FactorioServerManager.AppLogic/FactorioServerManager.AppLogic.csproj", "FactorioServerManager.AppLogic/"]
COPY ["FactorioServerManager.AppModel/FactorioServerManager.AppModel.csproj", "FactorioServerManager.AppModel/"]
COPY ["FactorioServerManager.DataStore/FactorioServerManager.DataStore.csproj", "FactorioServerManager.DataStore/"]
RUN dotnet restore "FactorioServerManager.WebUi/FactorioServerManager.WebUi.csproj"
COPY . .
WORKDIR "/src/FactorioServerManager.WebUi"
RUN dotnet build "FactorioServerManager.WebUi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FactorioServerManager.WebUi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FactorioServerManager.WebUi.dll"]