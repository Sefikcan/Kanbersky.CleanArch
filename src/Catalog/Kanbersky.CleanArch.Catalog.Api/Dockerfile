#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Catalog/Kanbersky.CleanArch.Catalog.Api/Kanbersky.CleanArch.Catalog.Api.csproj", "src/Catalog/Kanbersky.CleanArch.Catalog.Api/"]
COPY ["src/Catalog/Kanbersky.CleanArch.Catalog.Services/Kanbersky.CleanArch.Catalog.Services.csproj", "src/Catalog/Kanbersky.CleanArch.Catalog.Services/"]
COPY ["src/Catalog/Kanbersky.CleanArch.Catalog.Infrastracture/Kanbersky.CleanArch.Catalog.Infrastracture.csproj", "src/Catalog/Kanbersky.CleanArch.Catalog.Infrastracture/"]
COPY ["Kanbersky.CleanArch.Core/Kanbersky.CleanArch.Core.csproj", "Kanbersky.CleanArch.Core/"]
RUN dotnet restore "src/Catalog/Kanbersky.CleanArch.Catalog.Api/Kanbersky.CleanArch.Catalog.Api.csproj"
COPY . .
WORKDIR "/src/src/Catalog/Kanbersky.CleanArch.Catalog.Api"
RUN dotnet build "Kanbersky.CleanArch.Catalog.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kanbersky.CleanArch.Catalog.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kanbersky.CleanArch.Catalog.Api.dll"]
