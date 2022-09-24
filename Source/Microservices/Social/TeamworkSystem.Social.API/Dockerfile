#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TeamworkSystem.Social.API/TeamworkSystem.Social.API.csproj", "TeamworkSystem.Social.API/"]
COPY ["TeamworkSystem.Social.BusinessLogic/TeamworkSystem.Social.BusinessLogic.csproj", "TeamworkSystem.Social.BusinessLogic/"]
COPY ["TeamworkSystem.Social.DataAccess/TeamworkSystem.Social.DataAccess.csproj", "TeamworkSystem.Social.DataAccess/"]
COPY ["TeamworkSystem.Shared/TeamworkSystem.Shared.csproj", "TeamworkSystem.Shared/"]
COPY ["TeamworkSystem.EventBus.Messages/TeamworkSystem.EventBus.Messages.csproj", "TeamworkSystem.EventBus.Messages/"]
RUN dotnet restore "TeamworkSystem.Social.API/TeamworkSystem.Social.API.csproj"
COPY . .
WORKDIR "/src/TeamworkSystem.Social.API"
RUN dotnet build "TeamworkSystem.Social.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TeamworkSystem.Social.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeamworkSystem.Social.API.dll"]
