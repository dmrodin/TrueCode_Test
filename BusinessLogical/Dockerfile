FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BusinessLogical/BusinessLogical.csproj", "BusinessLogical/"]
RUN dotnet restore "BusinessLogical/BusinessLogical.csproj"
COPY . .
WORKDIR "/src/BusinessLogical"
RUN dotnet build "BusinessLogical.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BusinessLogical.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BusinessLogical.dll"]
