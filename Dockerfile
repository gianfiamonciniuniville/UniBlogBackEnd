# ----------- Build stage -----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY *.sln .
COPY ./UniBlog.WebApi/*.csproj ./UniBlog.WebApi/
RUN dotnet restore

# Copy everything else and build
COPY . .
WORKDIR /app/UniBlog.WebApi
RUN dotnet publish -c Release -o /out

# ----------- Runtime stage -----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /out ./

# Expose port (optional, Render detects from Dockerfile)
EXPOSE 8080

# Set environment variables (optional)
ENV ASPNETCORE_URLS=http://+:8080 \
    DOTNET_RUNNING_IN_CONTAINER=true

ENTRYPOINT ["dotnet", "/UniBlog.WebApi.dll"]
