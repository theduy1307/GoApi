FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Scheduling.Api/Scheduling.Api.csproj", "Services/Scheduling.Api/"]
COPY ["Services/Scheduling.Application/Scheduling.Application.csproj", "Services/Scheduling.Application/"]
COPY ["Services/Scheduling.Core/Scheduling.Core.csproj", "Services/Scheduling.Core/"]
COPY ["Services/Scheduling.Infrastructure/Scheduling.Infrastructure.csproj", "Services/Scheduling.Infrastructure/"]
RUN dotnet restore "Services/Scheduling.Api/Scheduling.Api.csproj"
COPY . .
WORKDIR "/src/Services/Scheduling.Api"
RUN dotnet build "Scheduling.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Scheduling.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Scheduling.Api.dll"]
