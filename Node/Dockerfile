﻿FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Node/Node.csproj", "Node/"]
RUN dotnet restore "Node/Node.csproj"
COPY . .
WORKDIR "/src/Node"
RUN dotnet build "Node.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Node.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Node.dll"]
