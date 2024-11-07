# Use the official .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS test-env

# Устанавливаем рабочую директорию
WORKDIR /app

# Копируем .csproj файл и устанавливаем зависимости
COPY ./src/ .
RUN dotnet restore
RUN dotnet build --configuration Release --no-restore


# Запускаем тесты
ENTRYPOINT ["dotnet", "test"]

# # Set working directory inside the container
# WORKDIR /app

# # Copy everything to the container
# COPY . .

# # Restore dependencies and build the project
# RUN dotnet restore ./src/LibraryApp.csproj
# RUN dotnet build ./src/LibraryApp.csproj --no-restore

# # Run tests
# Run dotnet test ./src/LibraryApp.csproj --no-build