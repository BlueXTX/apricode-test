FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["Games.Api/Games.Api.csproj", "Games.Api/"]
COPY ["Games.Application/Games.Application.csproj", "Games.Application/"]
COPY ["Games.Infrastructure/Games.Infrastructure.csproj", "Games.Infrastructure/"]
RUN dotnet restore "Games.Api/Games.Api.csproj"

COPY . .
WORKDIR "/src/Games.Api"
RUN dotnet build "Games.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Games.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Games.Api.dll"]
