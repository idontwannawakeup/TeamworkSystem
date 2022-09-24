#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TeamworkSystem.Content.API/TeamworkSystem.Content.API.csproj", "TeamworkSystem.Content.API/"]
COPY ["TeamworkSystem.Content.Application/TeamworkSystem.Content.Application.csproj", "TeamworkSystem.Content.Application/"]
COPY ["TeamworkSystem.Content.Domain/TeamworkSystem.Content.Domain.csproj", "TeamworkSystem.Content.Domain/"]
COPY ["TeamworkSystem.Content.Persistence/TeamworkSystem.Content.Persistence.csproj", "TeamworkSystem.Content.Persistence/"]
COPY ["TeamworkSystem.Shared/TeamworkSystem.Shared.csproj", "TeamworkSystem.Shared/"]
COPY ["TeamworkSystem.EventBus.Messages/TeamworkSystem.EventBus.Messages.csproj", "TeamworkSystem.EventBus.Messages/"]
RUN dotnet restore "TeamworkSystem.Content.API/TeamworkSystem.Content.API.csproj"
COPY . .
WORKDIR "/src/TeamworkSystem.Content.API"
RUN dotnet build "TeamworkSystem.Content.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TeamworkSystem.Content.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeamworkSystem.Content.API.dll"]
