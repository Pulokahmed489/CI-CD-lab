# Stage 1: Build and restore
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project and solution files
COPY Swagger.Tests/Swagger.Tests.csproj SwaggerProj/Swagger.Tests/
COPY Swagger.Api/Swagger.Api.csproj SwaggerProj/Swagger.Api/
COPY Swagger.Tests.sln SwaggerProj/

# Restore dependencies
RUN dotnet restore "Swagger.Tests.sln"

# Copy the rest of the source code
COPY . .

# Build the solution
RUN dotnet build "Swagger.Tests.sln" -c Release -o /app/build

EXPOSE 8080
ENTRYPOINT ["dotnet", "Swagger.Tests.dll"]
