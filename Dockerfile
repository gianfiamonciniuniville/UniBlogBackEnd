# ----------- Build stage -----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar a solução e todos os arquivos de projeto
COPY UniBlogBackEnd.sln ./
COPY UniBlog.WebApi/UniBlog.WebApi.csproj UniBlog.WebApi/
COPY UniBlog.Application/UniBlog.Application.csproj UniBlog.Application/
COPY UniBlog.Infrastructure/UniBlog.Infrastructure.csproj UniBlog.Infrastructure/
COPY UniBlog.Domain/UniBlog.Domain.csproj UniBlog.Domain/

# Restaurar dependências
RUN dotnet restore

# Copiar todo o conteúdo (agora que o restore funcionou)
COPY . .

# Definir a pasta de trabalho como o projeto principal da Web API
WORKDIR /app/UniBlog.WebApi

# Publicar a aplicação
RUN dotnet publish -c Release -o /out

# ----------- Runtime stage -----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /out ./

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080 \
    DOTNET_RUNNING_IN_CONTAINER=true

ENTRYPOINT ["dotnet", "UniBlog.WebApi.dll"]

