FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Source/Microservices/Content/Presentation/TeamworkSystem.Content.API/TeamworkSystem.Content.API.csproj", "TeamworkSystem.Content.API/"]
COPY ["Source/Microservices/Content/Core/TeamworkSystem.Content.Domain/TeamworkSystem.Content.Domain.csproj", "TeamworkSystem.Content.Domain/"]
COPY ["Source/Libraries/TeamworkSystem.Shared/TeamworkSystem.Shared.csproj", "TeamworkSystem.Shared/"]
COPY ["Source/Libraries/TeamworkSystem.EventBus.Messages/TeamworkSystem.EventBus.Messages.csproj", "TeamworkSystem.EventBus.Messages/"]
COPY ["Source/Microservices/Content/Infrastructure/TeamworkSystem.Content.Persistence/TeamworkSystem.Content.Persistence.csproj", "TeamworkSystem.Content.Persistence/"]
COPY ["Source/Microservices/Content/Core/TeamworkSystem.Content.Application/TeamworkSystem.Content.Application.csproj", "TeamworkSystem.Content.Application/"]
RUN dotnet restore "Source/Microservices/Content/Presentation/TeamworkSystem.Content.API/TeamworkSystem.Content.API.csproj"
COPY . .
WORKDIR "/src/TeamworkSystem.Content.API"
RUN dotnet build "TeamworkSystem.Content.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TeamworkSystem.Content.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeamworkSystem.Content.API.dll"]
