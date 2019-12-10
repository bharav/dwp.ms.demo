FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["services/dwp.ms.demo.vehicle.api/dwp.ms.demo.vehicle.api.csproj", "services/dwp.ms.demo.vehicle.api/"]
COPY ["EventBus/EventBusCL/EventBus.csproj","EventBus/EventBusCL"]
COPY ["EventBus/EventBusRabbitMQ/EventBusRabbitMQ.csproj","EventBus/EventBusRabbitMQ"]
COPY ["EventBus/IntegrationEventLogEF/IntegrationEventLogEF.csproj","EventBus/IntegrationEventLogEF"]
RUN dotnet restore "services/dwp.ms.demo.vehicle.api/dwp.ms.demo.vehicle.api.csproj"

COPY . .
WORKDIR "/src/services/dwp.ms.demo.vehicle.api"
RUN dotnet build "dwp.ms.demo.vehicle.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dwp.ms.demo.vehicle.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dwp.ms.demo.vehicle.api.dll"]