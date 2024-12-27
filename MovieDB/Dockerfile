FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MovieDB.csproj", "./"]
RUN dotnet restore "MovieDB.csproj"
COPY . .
RUN dotnet build "MovieDB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MovieDB.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "MovieDB.dll"]