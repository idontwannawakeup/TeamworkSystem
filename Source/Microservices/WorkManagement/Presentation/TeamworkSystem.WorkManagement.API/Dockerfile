FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 90
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Source/Microservices/WorkManagement/Presentation/TeamworkSystem.WorkManagement.API/TeamworkSystem.WorkManagement.API.csproj", "TeamworkSystem.WorkManagement.API/"]
COPY ["Source/Microservices/WorkManagement/Core/TeamworkSystem.WorkManagement.Domain/TeamworkSystem.WorkManagement.Domain.csproj", "TeamworkSystem.WorkManagement.Domain/"]
COPY ["Source/Libraries/TeamworkSystem.Shared/TeamworkSystem.Shared.csproj", "TeamworkSystem.Shared/"]
COPY ["Source/Libraries/TeamworkSystem.EventBus.Messages/TeamworkSystem.EventBus.Messages.csproj", "TeamworkSystem.EventBus.Messages/"]
COPY ["Source/Microservices/WorkManagement/Infrastructure/TeamworkSystem.WorkManagement.Persistence/TeamworkSystem.WorkManagement.Persistence.csproj", "TeamworkSystem.WorkManagement.Persistence/"]
COPY ["Source/Microservices/WorkManagement/Core/TeamworkSystem.WorkManagement.Application/TeamworkSystem.WorkManagement.Application.csproj", "TeamworkSystem.WorkManagement.Application/"]
RUN dotnet restore "Source/Microservices/WorkManagement/Presentation/TeamworkSystem.WorkManagement.API/TeamworkSystem.WorkManagement.API.csproj"
COPY . .
WORKDIR "/src/TeamworkSystem.WorkManagement.API"
RUN dotnet build "TeamworkSystem.WorkManagement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TeamworkSystem.WorkManagement.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeamworkSystem.WorkManagement.API.dll"]
