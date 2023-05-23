FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Source/Microservices/Identity/People/TeamworkSystem.Identity.People.API/TeamworkSystem.Identity.People.API.csproj", "TeamworkSystem.Identity.People.API/"]
COPY ["Source/Libraries/TeamworkSystem.EventBus.Messages/TeamworkSystem.EventBus.Messages.csproj", "TeamworkSystem.EventBus.Messages/"]
COPY ["Source/Microservices/Identity/People/TeamworkSystem.Identity.People.BusinessLogic/TeamworkSystem.Identity.People.BusinessLogic.csproj", "TeamworkSystem.Identity.People.BusinessLogic/"]
COPY ["Source/Microservices/Identity/Persistence/TeamworkSystem.Identity.Persistence.People/TeamworkSystem.Identity.Persistence.People.csproj", "TeamworkSystem.Identity.Persistence.People/"]
COPY ["Source/Libraries/TeamworkSystem.Shared/TeamworkSystem.Shared.csproj", "TeamworkSystem.Shared/"]
RUN dotnet restore "Source/Microservices/Identity/People/TeamworkSystem.Identity.People.API/TeamworkSystem.Identity.People.API.csproj"
COPY . .
WORKDIR "/src/TeamworkSystem.Identity.People.API"
RUN dotnet build "TeamworkSystem.Identity.People.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TeamworkSystem.Identity.People.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeamworkSystem.Identity.People.API.dll"]
