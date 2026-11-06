# Day 3 - Dockerfile for PatientOnLine.Api (.NET 10)
# Multi-stage build: Build + Runtime

# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["PatientOnLine.Api.csproj", "./"]
RUN dotnet restore "PatientOnLine.Api.csproj"
COPY . .
RUN dotnet build "PatientOnLine.Api.csproj" -c Release -o /app/build

# Stage 2: Publish
FROM build AS publish
RUN dotnet publish "PatientOnLine.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 3: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
# .NET 10 default port is 8080 inside container
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "PatientOnLine.Api.dll"]
