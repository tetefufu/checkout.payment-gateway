#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["checkout.payment-gateway.api/checkout.payment-gateway.api.csproj", "checkout.payment-gateway.api/"]
RUN dotnet restore "checkout.payment-gateway.api/checkout.payment-gateway.api.csproj"
COPY . .
WORKDIR "/src/checkout.payment-gateway.api"
RUN dotnet build "checkout.payment-gateway.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "checkout.payment-gateway.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "checkout.payment-gateway.api.dll"]