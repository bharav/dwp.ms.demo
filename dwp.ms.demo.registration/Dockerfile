FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["dwp.ms.demo.registration/dwp.ms.demo.registration.csproj", "dwp.ms.demo.registration/"]
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