# Stage 1: Build and restore
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project and solution files
COPY Swagger.Tests/Swagger.Tests.csproj .
COPY Swagger.Api/Swagger.Api.csproj .
COPY Swagger.Tests/Swagger.Tests.sln .

# Restore dependencies
RUN dotnet restore "Swagger.Tests.csproj"

# Copy the rest of the source code
COPY . .

WORKDIR /src
# Build the solution
RUN dotnet build "Swagger.Tests/Swagger.Tests.csproj" -c Release -o /app/build


EXPOSE 8080
ENTRYPOINT ["dotnet", "Swagger.Tests.dll"]
