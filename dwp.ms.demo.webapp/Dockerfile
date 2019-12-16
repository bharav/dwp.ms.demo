FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["../dwp.ms.demo.webapp/dwp.ms.demo.webapp.csproj", "../dwp.ms.demo.webapp/"]
RUN dotnet restore "../dwp.ms.demo.webapp/dwp.ms.demo.webapp.csproj"
COPY . .
WORKDIR "/src/../dwp.ms.demo.webapp"
RUN dotnet build "dwp.ms.demo.webapp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dwp.ms.demo.webapp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dwp.ms.demo.webapp.dll"]