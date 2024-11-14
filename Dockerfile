# Use the official .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS test-env

# Устанавливаем рабочую директорию
WORKDIR /app
EXPOSE 5000

# Копируем .csproj файл и устанавливаем зависимости
COPY . .
RUN dotnet restore ./src/LibraryApp.csproj
RUN dotnet build ./src/LibraryApp.csproj --configuration Release --no-restore
RUN ls

# Запускаем тесты
ENTRYPOINT ["dotnet", "test", "./src/LibraryApp.csproj"]