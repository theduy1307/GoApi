FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/MasterData.Api/MasterData.Api.csproj", "Services/MasterData.Api/"]
COPY ["Services/MasterData.Application/MasterData.Application.csproj", "Services/MasterData.Application/"]
COPY ["Services/MasterData.Core/MasterData.Core.csproj", "Services/MasterData.Core/"]
COPY ["Services/MasterData.Infrastructure/MasterData.Infrastructure.csproj", "Services/MasterData.Infrastructure/"]
RUN dotnet restore "Services/MasterData.Api/MasterData.Api.csproj"
COPY . .
WORKDIR "/src/Services/MasterData.Api"
RUN dotnet build "MasterData.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MasterData.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MasterData.Api.dll"]
