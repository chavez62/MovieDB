FROM mcr.microsoft.com/dotnet/aspnet:8.0-bookworm-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-bookworm-slim AS build
WORKDIR /src
COPY ["MovieDB.csproj", "./"]
RUN dotnet restore "MovieDB.csproj"
COPY . .
RUN dotnet build "MovieDB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MovieDB.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieDB.dll"]
