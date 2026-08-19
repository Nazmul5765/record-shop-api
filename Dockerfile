FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["RecordShop/RecordShop.csproj", "RecordShop/"]
RUN dotnet restore "RecordShop/RecordShop.csproj"

COPY . .

WORKDIR "/src/RecordShop"
RUN dotnet publish "RecordShop.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=build /app/publish .

CMD ["sh", "-c", "dotnet RecordShop.dll --urls http://0.0.0.0:${PORT:-8080}"]
