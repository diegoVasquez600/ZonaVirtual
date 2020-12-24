#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Zona.API/Zona.API.csproj", "Zona.API/"]
RUN dotnet restore "Zona.API/Zona.API.csproj"
COPY . .
WORKDIR "/src/Zona.API"
RUN dotnet build "Zona.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Zona.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Zona.API.dll"]