#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["backend/OnlineComputerShop.IdentityProvider/OnlineComputerShop.IdentityProvider.csproj", "backend/OnlineComputerShop.IdentityProvider/"]
COPY ["backend/OnlineComputerShop.Dal/OnlineComputerShop.Dal.csproj", "backend/OnlineComputerShop.Dal/"]
RUN dotnet restore "backend/OnlineComputerShop.IdentityProvider/OnlineComputerShop.IdentityProvider.csproj"
COPY . .
WORKDIR "/src/backend/OnlineComputerShop.IdentityProvider"
RUN dotnet build "OnlineComputerShop.IdentityProvider.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnlineComputerShop.IdentityProvider.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineComputerShop.IdentityProvider.dll"]