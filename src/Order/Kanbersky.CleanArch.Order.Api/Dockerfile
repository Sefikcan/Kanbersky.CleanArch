#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Order/Kanbersky.CleanArch.Order.Api/Kanbersky.CleanArch.Order.Api.csproj", "src/Order/Kanbersky.CleanArch.Order.Api/"]
COPY ["src/Order/Kanbersky.CleanArch.Order.Infrastructure/Kanbersky.CleanArch.Order.Infrastructure.csproj", "src/Order/Kanbersky.CleanArch.Order.Infrastructure/"]
COPY ["Kanbersky.CleanArch.Core/Kanbersky.CleanArch.Core.csproj", "Kanbersky.CleanArch.Core/"]
COPY ["src/Order/Kanbersky.CleanArch.Order.Services/Kanbersky.CleanArch.Order.Services.csproj", "src/Order/Kanbersky.CleanArch.Order.Services/"]
RUN dotnet restore "src/Order/Kanbersky.CleanArch.Order.Api/Kanbersky.CleanArch.Order.Api.csproj"
COPY . .
WORKDIR "/src/src/Order/Kanbersky.CleanArch.Order.Api"
RUN dotnet build "Kanbersky.CleanArch.Order.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kanbersky.CleanArch.Order.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kanbersky.CleanArch.Order.Api.dll"]
