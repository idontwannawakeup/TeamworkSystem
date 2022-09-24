#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TeamworkSystem.Identity.API/TeamworkSystem.Identity.API.csproj", "TeamworkSystem.Identity.API/"]
COPY ["TeamworkSystem.Identity.BusinessLogic/TeamworkSystem.Identity.BusinessLogic.csproj", "TeamworkSystem.Identity.BusinessLogic/"]
COPY ["TeamworkSystem.Identity.Persistence.People/TeamworkSystem.Identity.Persistence.People.csproj", "TeamworkSystem.Identity.Persistence.People/"]
COPY ["TeamworkSystem.Shared/TeamworkSystem.Shared.csproj", "TeamworkSystem.Shared/"]
COPY ["TeamworkSystem.EventBus.Messages/TeamworkSystem.EventBus.Messages.csproj", "TeamworkSystem.EventBus.Messages/"]
RUN dotnet restore "TeamworkSystem.Identity.API/TeamworkSystem.Identity.API.csproj"
COPY . .
WORKDIR "/src/TeamworkSystem.Identity.API"
RUN dotnet build "TeamworkSystem.Identity.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TeamworkSystem.Identity.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeamworkSystem.Identity.API.dll"]
