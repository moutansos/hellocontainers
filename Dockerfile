FROM mcr.microsoft.com/dotnet/runtime-deps:6.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["hellocontainers/hellocontainers.csproj", "hellocontainers/"]
RUN dotnet restore "hellocontainers/hellocontainers.csproj"
COPY . .
WORKDIR "/src/hellocontainers"
RUN dotnet build "hellocontainers.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "hellocontainers.csproj" -c Release -o /app/publish -r linux-musl-arm64 --self-contained

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["./hellocontainers"]
