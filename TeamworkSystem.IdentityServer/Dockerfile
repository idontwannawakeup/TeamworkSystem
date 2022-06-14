#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TeamworkSystem.IdentityServer/TeamworkSystem.IdentityServer.csproj", "TeamworkSystem.IdentityServer/"]
COPY ["TeamworkSystem.Identity.BusinessLogic/TeamworkSystem.Identity.BusinessLogic.csproj", "TeamworkSystem.Identity.BusinessLogic/"]
COPY ["TeamworkSystem.Identity.DataAccess/TeamworkSystem.Identity.DataAccess.csproj", "TeamworkSystem.Identity.DataAccess/"]
COPY ["TeamworkSystem.Shared/TeamworkSystem.Shared.csproj", "TeamworkSystem.Shared/"]
COPY ["TeamworkSystem.EventBus.Messages/TeamworkSystem.EventBus.Messages.csproj", "TeamworkSystem.EventBus.Messages/"]
RUN dotnet restore "TeamworkSystem.IdentityServer/TeamworkSystem.IdentityServer.csproj"
COPY . .
WORKDIR "/src/TeamworkSystem.IdentityServer"
RUN dotnet build "TeamworkSystem.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TeamworkSystem.IdentityServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeamworkSystem.IdentityServer.dll"]
