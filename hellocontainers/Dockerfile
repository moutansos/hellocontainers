#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["hellocontainers/hellocontainers.csproj", "hellocontainers/"]
RUN dotnet restore "hellocontainers/hellocontainers.csproj"
COPY . .
WORKDIR "/src/hellocontainers"
RUN dotnet build "hellocontainers.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "hellocontainers.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "hellocontainers.dll"]