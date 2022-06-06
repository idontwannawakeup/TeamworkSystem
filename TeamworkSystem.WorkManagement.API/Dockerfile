#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TeamworkSystem.WorkManagement.API/TeamworkSystem.WorkManagement.API.csproj", "TeamworkSystem.WorkManagement.API/"]
COPY ["TeamworkSystem.WorkManagement.BusinessLogic/TeamworkSystem.WorkManagement.BusinessLogic.csproj", "TeamworkSystem.WorkManagement.BusinessLogic/"]
COPY ["TeamworkSystem.WorkManagement.DataAccess/TeamworkSystem.WorkManagement.DataAccess.csproj", "TeamworkSystem.WorkManagement.DataAccess/"]
COPY ["TeamworkSystem.Shared/TeamworkSystem.Shared.csproj", "TeamworkSystem.Shared/"]
RUN dotnet restore "TeamworkSystem.WorkManagement.API/TeamworkSystem.WorkManagement.API.csproj"
COPY . .
WORKDIR "/src/TeamworkSystem.WorkManagement.API"
RUN dotnet build "TeamworkSystem.WorkManagement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TeamworkSystem.WorkManagement.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeamworkSystem.WorkManagement.API.dll"]
