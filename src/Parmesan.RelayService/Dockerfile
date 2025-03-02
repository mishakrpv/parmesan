FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Parmesan.RelayService/Parmesan.RelayService.csproj", "src/Parmesan.RelayService/"]
RUN dotnet restore "src/Parmesan.RelayService/Parmesan.RelayService.csproj"
COPY . .
WORKDIR "/src/src/Parmesan.RelayService"
RUN dotnet build "Parmesan.RelayService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Parmesan.RelayService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Parmesan.RelayService.dll"]
