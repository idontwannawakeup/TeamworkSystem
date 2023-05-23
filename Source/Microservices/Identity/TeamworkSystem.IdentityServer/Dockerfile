FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Source/Microservices/Identity/TeamworkSystem.IdentityServer/TeamworkSystem.IdentityServer.csproj", "TeamworkSystem.IdentityServer/"]
COPY ["Source/Microservices/Identity/Persistence/TeamworkSystem.Identity.Persistence.People/TeamworkSystem.Identity.Persistence.People.csproj", "TeamworkSystem.Identity.Persistence.People/"]
COPY ["Source/Libraries/TeamworkSystem.Shared/TeamworkSystem.Shared.csproj", "TeamworkSystem.Shared/"]
COPY ["Source/Microservices/Identity/Persistence/TeamworkSystem.Identity.Persistence.Operational/TeamworkSystem.Identity.Persistence.Operational.csproj", "TeamworkSystem.Identity.Persistence.Operational/"]
COPY ["Source/Microservices/Identity/Persistence/TeamworkSystem.Identity.Persistence.Configuration/TeamworkSystem.Identity.Persistence.Configuration.csproj", "TeamworkSystem.Identity.Persistence.Configuration/"]
COPY ["Source/Libraries/TeamworkSystem.EventBus.Messages/TeamworkSystem.EventBus.Messages.csproj", "TeamworkSystem.EventBus.Messages/"]
RUN dotnet restore "Source/Microservices/Identity/TeamworkSystem.IdentityServer/TeamworkSystem.IdentityServer.csproj"
COPY . .
WORKDIR "/src/TeamworkSystem.IdentityServer"
RUN dotnet build "TeamworkSystem.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TeamworkSystem.IdentityServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeamworkSystem.IdentityServer.dll"]
