# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/aspnet:6.0 as base

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /src
COPY DishDeliveryWebSite.csproj .
COPY . .
RUN dotnet restore "DishDeliveryWebSite.csproj"

FROM build as publish
WORKDIR /src
RUN dotnet publish "DishDeliveryWebSite.csproj" -c debug -o /app/publish

# Build runtime image
FROM base as final
WORKDIR /app/run
COPY --from=publish app/publish .
ENTRYPOINT ["dotnet", "DishDeliveryWebSite.dll"]