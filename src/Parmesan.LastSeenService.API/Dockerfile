FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Parmesan.LastSeenService.API/Parmesan.LastSeenService.API.csproj", "src/Parmesan.LastSeenService.API/"]
RUN dotnet restore "src/Parmesan.LastSeenService.API/Parmesan.LastSeenService.API.csproj"
COPY . .
WORKDIR "/src/src/Parmesan.LastSeenService.API"
RUN dotnet build "Parmesan.LastSeenService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Parmesan.LastSeenService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Parmesan.LastSeenService.API.dll"]
