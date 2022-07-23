#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TeamworkSystem.WebClient/TeamworkSystem.WebClient.csproj", "TeamworkSystem.WebClient/"]
RUN dotnet restore "TeamworkSystem.WebClient/TeamworkSystem.WebClient.csproj"
COPY . .
WORKDIR "/src/TeamworkSystem.WebClient"
RUN dotnet build "TeamworkSystem.WebClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TeamworkSystem.WebClient.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeamworkSystem.WebClient.dll"]
