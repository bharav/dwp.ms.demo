FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["dwp.ms.demo.registration/dwp.ms.demo.registration.csproj", "dwp.ms.demo.registration/"]
COPY ["dwp.ms.demo.registration.domain/dwp.ms.demo.registration.domain.csproj", "dwp.ms.demo.registration.domain/"]
COPY ["dwp.ms.demo.registration.infastructure/dwp.ms.demo.registration.infastructure.csproj", "dwp.ms.demo.registration.infastructure/"]
COPY ["EventBus/EventBusCL/EventBus.csproj","EventBus/EventBusCL"]
COPY ["EventBus/EventBusRabbitMQ/EventBusRabbitMQ.csproj","EventBus/EventBusRabbitMQ"]
COPY ["EventBus/IntegrationEventLogEF/IntegrationEventLogEF.csproj","EventBus/IntegrationEventLogEF"]
RUN dotnet restore "dwp.ms.demo.registration/dwp.ms.demo.registration.csproj"
COPY . .
WORKDIR "/src/dwp.ms.demo.registration"
RUN dotnet build "dwp.ms.demo.registration.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dwp.ms.demo.registration.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dwp.ms.demo.registration.dll"]
