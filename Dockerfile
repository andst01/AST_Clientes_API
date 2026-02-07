# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia apenas os csproj para cache de restore
COPY ["src/Clientes.Api/Clientes.Api.csproj", "src/Clientes.Api/"]
COPY ["src/Clientes.Infra.CrossCuting/Clientes.Infra.CrossCuting.csproj", "src/Clientes.Infra.CrossCuting/"]
COPY ["src/Clientes.Infra.Data/Clientes.Infra.Data.csproj", "src/Clientes.Infra.Data/"]
COPY ["src/Clientes.Domain/Clientes.Domain.csproj", "src/Clientes.Domain/"]
COPY ["src/Clientes.Application/Clientes.Application.csproj", "src/Clientes.Application/"]

# Restaura pacotes
RUN dotnet restore "src/Clientes.Api/Clientes.Api.csproj"

# Copia todo o código
COPY . .

# Publica especificando **o caminho completo do csproj**
RUN dotnet publish "src/Clientes.Api/Clientes.Api.csproj" -c Debug -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Variáveis de ambiente para Development
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV ASPNETCORE_URLS=http://+:4092

# Copia os binários
COPY --from=build /app/publish .

EXPOSE 4092

ENTRYPOINT ["dotnet", "Clientes.Api.dll"]
